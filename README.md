Overview:
The purpouse of this project is to showcase ARFoundation possibilites.

Usage:
Point phone camera on flat surface (floot, table). The indicator appreas. Click indicator to spawn character. 
Click the screen to rotate the character and collect the food.
Each food collected should result a random dog fact appear for 3 second. Food pieces counter should increment.

Highlights:
- Injected dependency (ICharacterMovementProvider, IRaycastProvider) via GameController.cs
- Possible collectibles extension via ICollectible
- Generic async http client (WIP)
- Injected dependency of client response serializer
- UniRx usage: Chacater.cs -> OnTriggerEnter, CollectibleCounter.cs
- A few test NUnit

# AR-Project
