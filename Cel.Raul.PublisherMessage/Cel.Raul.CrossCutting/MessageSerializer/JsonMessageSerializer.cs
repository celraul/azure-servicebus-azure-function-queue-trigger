using Newtonsoft.Json;

namespace Cel.Raul.CrossCutting.MessageSerializer
{
    public class JsonMessageSerializer : IMessageSerializer
	{
		public T Deserialize<T>(string message)
		{
			var obj = JsonConvert.DeserializeObject<T>(message);
			return obj;
		}

		public string Serialize(object obj)
		{
			var message = JsonConvert.SerializeObject(obj);
			return message;
		}
	}
}
