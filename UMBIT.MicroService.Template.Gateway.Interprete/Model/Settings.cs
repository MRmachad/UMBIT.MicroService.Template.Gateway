using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UMBIT.MicroService.Template.Gateway.Interprete.Model
{

    public class Settings
    {
        [JsonPropertyName("DownstreamPathTemplate")]
        public string DownstreamPathTemplate { get; set; }

        [JsonPropertyName("UpstreamPathTemplate")]
        public string UpstreamPathTemplate { get; set; }

        [JsonPropertyName("UpstreamHttpMethod")]
        public List<string> UpstreamHttpMethod { get; set; }

        [JsonPropertyName("DownstreamHttpMethod")]
        public string DownstreamHttpMethod { get; set; }

        [JsonPropertyName("DownstreamHttpVersion")]
        public string DownstreamHttpVersion { get; set; }

        [JsonPropertyName("AddHeadersToRequest")]
        public AddHeadersToRequest AddHeadersToRequest { get; set; }

        [JsonPropertyName("AddClaimsToRequest")]
        public AddClaimsToRequest AddClaimsToRequest { get; set; }

        [JsonPropertyName("RouteClaimsRequirement")]
        public RouteClaimsRequirement RouteClaimsRequirement { get; set; }

        [JsonPropertyName("AddQueriesToRequest")]
        public AddQueriesToRequest AddQueriesToRequest { get; set; }

        [JsonPropertyName("RequestIdKey")]
        public string RequestIdKey { get; set; }

        [JsonPropertyName("FileCacheOptions")]
        public FileCacheOptions FileCacheOptions { get; set; }

        [JsonPropertyName("RouteIsCaseSensitive")]
        public bool RouteIsCaseSensitive { get; set; }

        [JsonPropertyName("ServiceName")]
        public string ServiceName { get; set; }

        [JsonPropertyName("DownstreamScheme")]
        public string DownstreamScheme { get; set; }

        [JsonPropertyName("DownstreamHostAndPorts")]
        public List<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }

        [JsonPropertyName("QoSOptions")]
        public QoSOptions QoSOptions { get; set; }

        [JsonPropertyName("LoadBalancer")]
        public string LoadBalancer { get; set; }

        [JsonPropertyName("RateLimitOptions")]
        public RateLimitOptions RateLimitOptions { get; set; }

        [JsonPropertyName("AuthenticationOptions")]
        public AuthenticationOptions AuthenticationOptions { get; set; }

        [JsonPropertyName("HttpHandlerOptions")]
        public HttpHandlerOptions HttpHandlerOptions { get; set; }

        [JsonPropertyName("DangerousAcceptAnyServerCertificateValidator")]
        public bool DangerousAcceptAnyServerCertificateValidator { get; set; }

        [JsonPropertyName("SecurityOptions")]
        public SecurityOptions SecurityOptions { get; set; }

        [JsonPropertyName("SwaggerKey")]
        public string SwaggerKey { get; internal set; }

        [JsonPropertyName("BaseUrl")]
        public string BaseUrl { get; internal set; }
    }

    public class AddClaimsToRequest
    {
    }

    public class AddHeadersToRequest
    {
    }

    public class AddQueriesToRequest
    {
    }

    public class AuthenticationOptions
    {
        [JsonPropertyName("AuthenticationProviderKey")]
        public string AuthenticationProviderKey { get; set; }

        [JsonPropertyName("AllowedScopes")]
        public List<object> AllowedScopes { get; set; }
    }

    public class DownstreamHostAndPort
    {
        [JsonPropertyName("Host")]
        public string Host { get; set; }

        [JsonPropertyName("Port")]
        public int Port { get; set; }
    }

    public class FileCacheOptions
    {
        [JsonPropertyName("TtlSeconds")]
        public int TtlSeconds { get; set; }

        [JsonPropertyName("Region")]
        public string Region { get; set; }
    }

    public class HttpHandlerOptions
    {
        [JsonPropertyName("AllowAutoRedirect")]
        public bool AllowAutoRedirect { get; set; }

        [JsonPropertyName("UseCookieContainer")]
        public bool UseCookieContainer { get; set; }

        [JsonPropertyName("UseTracing")]
        public bool UseTracing { get; set; }

        [JsonPropertyName("MaxConnectionsPerServer")]
        public int MaxConnectionsPerServer { get; set; }
    }

    public class QoSOptions
    {
        [JsonPropertyName("ExceptionsAllowedBeforeBreaking")]
        public int ExceptionsAllowedBeforeBreaking { get; set; }

        [JsonPropertyName("DurationOfBreak")]
        public int DurationOfBreak { get; set; }

        [JsonPropertyName("TimeoutValue")]
        public int TimeoutValue { get; set; }
    }

    public class RateLimitOptions
    {
        [JsonPropertyName("ClientWhitelist")]
        public List<object> ClientWhitelist { get; set; }

        [JsonPropertyName("EnableRateLimiting")]
        public bool EnableRateLimiting { get; set; }

        [JsonPropertyName("Period")]
        public string Period { get; set; }

        [JsonPropertyName("PeriodTimespan")]
        public int PeriodTimespan { get; set; }

        [JsonPropertyName("Limit")]
        public int Limit { get; set; }
    }

    public class RouteClaimsRequirement
    {
    }

    public class SecurityOptions
    {
        [JsonPropertyName("IPAllowedList")]
        public List<object> IPAllowedList { get; set; }

        [JsonPropertyName("IPBlockedList")]
        public List<object> IPBlockedList { get; set; }

        [JsonPropertyName("ExcludeAllowedFromBlocked")]
        public bool ExcludeAllowedFromBlocked { get; set; }
    }


}
