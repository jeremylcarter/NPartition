## NPartition : Split up your workload

NPartition is a simple persistent producer partition cache. What does that mean? Well it means it remembers what partition a producer belongs to and allows you to silo your workload into multiple partitions to avoid any multi-threaded headaches or concurrency issues.

## Rationale

NPartition fills the void of persistent Dictionary<int, string> where int is the partition and string is the name of the producer. This allows producers or unique keys to have a persistent unique integer assigned to them for their lifetime.

## Terms

Producer 			: An entity, device or any unique identifier that whereby work is aggregated.
Partition			: A group of Producers that are assigned a unique integer for their lifetime.
Topic				: A group of Partitions. A topic is named using a lowercase culture invariant string.
Topic Coordinator 	: Manages a topic and assigns producers to partitions based on a partition with the lowest producer count value.
Coordinator			: Manages multiple Topic Coordinators

