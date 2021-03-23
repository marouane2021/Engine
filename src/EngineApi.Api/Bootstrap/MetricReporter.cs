using Microsoft.Extensions.Logging;
using Prometheus;
using System;

namespace EngineApi.Api.Bootstrap
{
    public class MetricReporter
    {
        private readonly ILogger<MetricReporter> _logger;
        private readonly Counter _requestCounter;
        private readonly Histogram _responseTimeHistogram;

        public MetricReporter()
        { }
        public MetricReporter(ILogger<MetricReporter> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _requestCounter =
                Metrics.CreateCounter("totalrequestsToGetAllScopes", "The total number of requests serviced by this API.");

            _responseTimeHistogram = Metrics.CreateHistogram("request_duration_seconds",
                "The duration in seconds between the response to a request.", new HistogramConfiguration
                {
                    Buckets = Histogram.ExponentialBuckets(0.01, 2, 10),
                    LabelNames = new[] { "status_code", "method" }
                });
        }

        public void RegisterRequest()
        {
            if (_requestCounter != null)
                _requestCounter.Inc();
        }

        public void RegisterResponseTime(int statusCode, string method, TimeSpan elapsed)
        {
            _responseTimeHistogram.Labels(statusCode.ToString(), method).Observe(elapsed.TotalSeconds);
        }
    }
}
