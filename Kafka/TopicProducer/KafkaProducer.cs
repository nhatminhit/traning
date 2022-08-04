using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using TopicProducer;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();
try
{
    CrawlSanKeToan crawlsanketoan = new CrawlSanKeToan();
    var result = crawlsanketoan.Member();
    var response = await producer.ProduceAsync("test-topic", new Message<Null, string>
    {
        Value = JsonConvert.SerializeObject(result)
    }) ;
        Console.WriteLine(response.Value);
}
catch (ProduceException<Null, string> exc)
{

    Console.WriteLine(exc.Message);
}

//Data Source=HOANGNHATMINH\SQLEXPRESS;Initial Catalog=CrawlData;Integrated Security=True