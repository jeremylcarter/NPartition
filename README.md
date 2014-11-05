## NPartition : Split up your workload

NPartition is a simple persistent producer partition cache. What does that mean? Well it means it remembers what partition a producer belongs to and allows you to silo your workload into multiple partitions to avoid any multi-threaded headaches or concurrency issues. NPartition does not store any events or items that require processing, rather it acts as a persistent store of the partition each item belongs to.

## Rationale

NPartition fills the void of persistent Dictionary<int, string> where int is the partition and string is the name of the producer. This allows producers or unique keys to have a persistent unique integer assigned to them for their lifetime. NPartition gets out of your way and allows you to model your code to eventually migrate to Kafka, Azure Event Hubs or Amazon Kinesis.

I am using NPartition to provide an extremely lightweight Kafka like producer partitioner. When processing items you want to ensure that you aren't processing DeviceId1234 items over the top of each other. Perhaps an easy solution would be to use an event streaming software and aggregate the events. In most cases though you just need a quick fix and NPartition is just that. You'll be up and running within minutes and you'll be able to increase your processing throughput whilst ensuring items are processed on time.

## Terms

*Producer* 			: An entity, device or any unique identifier that whereby work is aggregated.<br/>
*Partition*			: A group of Producers that are assigned a unique integer for their lifetime.<br/>
*Topic*				: A group of Partitions. A topic is named using a lowercase culture invariant string.<br/>
*Topic Coordinator* : Manages a topic and assigns producers to partitions based on a partition with the lowest producer count value.<br/>
*Coordinator*		: Manages multiple Topic Coordinators<br/>

## Usage Example

Lets say you have a 500 telemetry devices and you want to process or re-process information as quickly as possible. The best idea would be to use Azure Event Hubs or Amazon Kinesis. If you cannot use these services then install NPartition on your main processing server or run it on a small linux box using Mono. 

Use the NPartition.Client library and ensure you include Json.net from Nuget or your own source. <br/>
In your processing code you could partition the items you need to process by the telemetry device id, perhaps this is the IMEI or another unique identifier. Once you have this done you can utilise the code in NPartition.Processing as a base to setup the processing of your partitioned items. Each partition is capable of executing items continuously one by one, or if you care to write more complex code you could process all items in a partition. NPartition does not store the items you need to process.

![Overview](http://i.imgur.com/jhnLvrK.png)

## Requirements

Currently NPartition uses .net 4.5 but it can be modified to use 4.0 easily.