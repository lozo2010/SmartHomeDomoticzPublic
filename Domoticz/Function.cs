using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Domoticz.Auxiliar;
using Domoticz.Models;
using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;
using RKon.Alexa.NET46.Payloads;
using RKon.Alexa.NET46.Request;
using RKon.Alexa.NET46.Response;
using RKon.Alexa.NET46.Types;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Domoticz
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// 

        DomoticzApi domoticz = new DomoticzApi();
        Dictionary<string, string> cookiesTemperature = new Dictionary<string, string>()
                    {
                        { "Temperatura","Temperatura" }
                    };
        Dictionary<string, string> cookiesTermostato = new Dictionary<string, string>()
                    {
                        { "Termostato","Termostato" }
                    };

        public object FunctionHandler(object jsonString)
        {

            SmartHomeRequest request = JsonConvert.DeserializeObject<SmartHomeRequest>(jsonString.ToString());
            LambdaLogger.Log(JsonConvert.SerializeObject(request) + Environment.NewLine);


            if (request.Directive.Header.Name == HeaderNames.DISCOVERY_REQUEST)
            {

                SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
                Event e = response.Event as Event;
                DiscoveryPayload p = e.Payload as DiscoveryPayload;



                foreach (var tem in domoticz.GetTemperatureDevice().result)
                {
                     var setTermostato = domoticz.GetDevices().result.Where(x => Convert.ToInt32(x.ID) == Convert.ToInt32(tem.ID) && x.SubType == "SetPoint").FirstOrDefault();
                    if (setTermostato != null)
                    {
                        List<DisplayCategory> categoriest = new List<DisplayCategory>() { DisplayCategory.THERMOSTAT };
                        List<Capability> capabilitiest = new List<Capability>();
                        capabilitiest.Add(new AlexaInterface("Alexa", "3", null, null, null, null));
                        capabilitiest.Add(new AlexaInterface(Namespaces.ALEXA_THERMOSTATCONTROLLER, "3", new List<string>() { PropertyNames.TARGET_SETPOINT, PropertyNames.THERMOSTATMODE }, true, true));
                        capabilitiest.Add(new AlexaInterface(Namespaces.ALEXA_TEMPERATURESENSOR, "3", new List<string>() { PropertyNames.TEMPERATURE }, true, true));
                        capabilitiest.Add(new AlexaInterface(Namespaces.ALEXA_ENDPOINTHEALTH, "3", new List<string>() { PropertyNames.CONNECTIVITY }, true, true));
                        p.Endpoints.Add(new ResponseEndpoint(setTermostato.idx, setTermostato.HardwareName, setTermostato.Name, setTermostato.Description, cookiesTermostato, categoriest, capabilitiest));
                    }
                        List<DisplayCategory> categories = new List<DisplayCategory>() { DisplayCategory.TEMPERATURE_SENSOR };
                        List<Capability> capabilities = new List<Capability>();
                        capabilities.Add(new AlexaInterface("Alexa", "3", null, null, null, null));
                        //capabilities.Add(new AlexaInterface(Namespaces.ALEXA_THERMOSTATCONTROLLER, "3", new List<string>() { PropertyNames.TARGET_SETPOINT, PropertyNames.THERMOSTATMODE }, true, true));
                        capabilities.Add(new AlexaInterface(Namespaces.ALEXA_TEMPERATURESENSOR, "3", new List<string>() { PropertyNames.TEMPERATURE }, true, true));
                        capabilities.Add(new AlexaInterface(Namespaces.ALEXA_ENDPOINTHEALTH, "3", new List<string>() { PropertyNames.CONNECTIVITY }, true, true));
                        p.Endpoints.Add(new ResponseEndpoint(tem.idx, tem.HardwareName, tem.Name, tem.Description, cookiesTemperature, categories, capabilities));    
                }


                return response;
            }
            else if(request.Directive.Header.Name == HeaderNames.REPORT_STATE)
            {

                LambdaLogger.Log(request.Directive.Endpoint.Cookie.GetValueOrDefault("Termostato") + Environment.NewLine);
                SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);

                if (request.Directive.Endpoint.Cookie.GetValueOrDefault("Termostato") == "Termostato")
                {
                    response.Context = new Context();
                    Setpoint temperaturaset = new Setpoint(domoticz.GetTemperatureDataDevice(request.Directive.Endpoint.EndpointID), Scale.CELSIUS);

                    Property p = new Property(Namespaces.ALEXA_THERMOSTATCONTROLLER, PropertyNames.TARGET_SETPOINT,temperaturaset, DateTime.Now, 200);
                    Property p3 = new Property(Namespaces.ALEXA_COLORTEMPERATURECONTROLLER, PropertyNames.THERMOSTATMODE,ThermostatModes.HEAT, DateTime.Now, 200);
                    ConnectivityPropertyValue value = new ConnectivityPropertyValue(ConnectivityModes.OK);
                    Property p4 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, value,DateTime.Now, 200);
                    response.Context.Properties.Add(p);
                    response.Context.Properties.Add(p3);
                    response.Context.Properties.Add(p4);
                    Event e = response.Event as Event;
                    e.Endpoint = new Endpoint(request.Directive.Endpoint.EndpointID, request.Directive.Endpoint.Scope);
                }
                else if (request.Directive.Endpoint.Cookie.GetValueOrDefault("Temperatura") == "Temperatura")
                {
                    response.Context = new Context();
                    Setpoint s = new Setpoint(domoticz.GetTemperatureDataDevice(request.Directive.Endpoint.EndpointID), Scale.CELSIUS);
                    Property p = new Property(Namespaces.ALEXA_TEMPERATURESENSOR, PropertyNames.TEMPERATURE, s, DateTime.Now, 200);
                    ConnectivityPropertyValue value = new ConnectivityPropertyValue(ConnectivityModes.OK);
                    Property p2 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, value, DateTime.Now, 200);
                    response.Context.Properties.Add(p);
                    response.Context.Properties.Add(p2);
                    Event e = response.Event as Event;
                    e.Endpoint = new Endpoint(request.Directive.Endpoint.EndpointID, request.Directive.Endpoint.Scope);

                }
                return response;
            }
            else if (request.Directive.Header.Name == HeaderNames.SETTARGETTEMPERATURE)
            {
                SmartHomeResponse response = new SmartHomeResponse(request.Directive.Header);
                response.Context = new Context();

                LambdaLogger.Log(JsonConvert.SerializeObject(request.Directive.Payload) + Environment.NewLine);
                PayloadTermostato termostato = JsonConvert.DeserializeObject<PayloadTermostato>(JsonConvert.SerializeObject(request.Directive.Payload));
                Property p = new Property(Namespaces.ALEXA_THERMOSTATCONTROLLER, PropertyNames.TARGET_SETPOINT,
                    new Setpoint(termostato.targetSetpoint.value, Scale.CELSIUS), DateTime.Now, 200);
                Property p3 = new Property(Namespaces.ALEXA_COLORTEMPERATURECONTROLLER, PropertyNames.THERMOSTATMODE,ThermostatModes.HEAT, DateTime.Now, 200);
                ConnectivityPropertyValue value;
                if (domoticz.SetTemperatureTermostato(request.Directive.Endpoint.EndpointID, termostato.targetSetpoint.value.ToString()))
                {
                    value = new ConnectivityPropertyValue(ConnectivityModes.OK);
                }
                else
                {
                    value = new ConnectivityPropertyValue(ConnectivityModes.UNREACHABLE);
                }
                Property p4 = new Property(Namespaces.ALEXA_ENDPOINTHEALTH, PropertyNames.CONNECTIVITY, value,DateTime.Now, 200);
                response.Context.Properties.Add(p);
                response.Context.Properties.Add(p3);
                response.Context.Properties.Add(p4);
                Event e = response.Event as Event;
                e.Endpoint = new Endpoint(request.Directive.Endpoint.EndpointID, request.Directive.Endpoint.Scope);
                return response;
            }
            else
            {
                return request;
            }
        }
    }
}
