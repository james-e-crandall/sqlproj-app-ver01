CRDT

A Conflict-free Replicated Data Type (CRDT) is a special data structure used in distributed computing that allows multiple computers (replicas) to update data independently, concurrently, and without central coordination, while guaranteeing that all copies will automatically merge to the exact same state.


You can learn more about the formal concepts on Conflict-free Replicated Data Type - Wikipedia or visit CRDT.tech.


How CRDTs Work

• No Coordination Needed: Users or nodes can read and write to their local copy of the data offline or in parallel without locking or waiting for other servers.
• Automatic Convergence: When network connections restore, the system merges the changes using built-in mathematical rules rather than manual conflict resolution.
• Core Mathematical Rules: To guarantee consistency, CRDT operations must be commutative (the order of application does not matter), associative (grouping does not matter), and idempotent (applying the same update multiple times has no extra effect).


The Two Main Types of CRDTs

1. State-based CRDTs (CvRDT): Replicas send their entire local state to other nodes, which then merge the states using a function that produces a combined, up-to-date state.
2. Operation-based CRDTs (CmRDT): Replicas broadcast individual mutation operations (like "add 5" or "insert character X") across the network, and other nodes apply those operations in causal order.


Common Data Structures Built with CRDTs

• Counters: Grow-only counters (G-counters) or positive-negative counters (PN-counters) that safely track tallies across nodes.
• Registers: Last-Writer-Wins (LWW) registers that pick a value based on timestamps or logical clocks.
• Sets: Grow-only sets or Observed-Remove sets (OR-sets) where items can be added and removed concurrently.
• Sequences / Text: Character- or block-level data structures used in collaborative document editors.


Common Use Cases

• Collaborative Editors: Real-time and offline text editors like Automerge or Yjs allow multiple people to type simultaneously.
• Distributed Databases: Multi-region systems (such as Redis Enterprise) use CRDTs to handle active-active geo-distribution with low latency.
• Local-First / Offline Apps: Mobile apps or note-taking tools (like Apple Notes) sync changes smoothly once a device reconnects to the internet.

