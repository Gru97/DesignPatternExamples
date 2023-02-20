using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExamples.Builder.SimpleBuilder
{
    public class MyUrlBuilder
    {
        private string _scheme="http";
        private string _host=String.Empty;
        private string _port = String.Empty;
        private Action<QueryParamsBuilder> _action;

        public MyUrlBuilder WithScheme(string scheme)
        {
            _scheme = scheme;
            return this;
        }
        public MyUrlBuilder WithHost(string host)
        {
            _host = host;
            return this;
        }
        public MyUrlBuilder WithPort(string port)
        {
            _port = port;
            return this;
        }

        public MyUrlBuilder WithQueryParams(Action<QueryParamsBuilder> action)
        {
            _action=action;
            return this;
        }
        public string Build()
        {
            var queryParamBuilder = new QueryParamsBuilder();
            _action(queryParamBuilder);
            //http://googlge.com:8080
            return $"{_scheme}://{_host}:{_port}?{queryParamBuilder.Build()}";
        }
    }

    public class QueryParamsBuilder
    {
        private readonly Dictionary<string, string> _dictionary;

        public QueryParamsBuilder()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public QueryParamsBuilder WithParams(string key, string value)
        {
            _dictionary.Add(key,value);
            return this;
        }

        public string Build()
        {
            string queryParam=string.Empty;
            foreach (var item in _dictionary)
            { 
                queryParam += $"{item.Key}={item.Value}";
            }
            return queryParam;
        }
    }
}
