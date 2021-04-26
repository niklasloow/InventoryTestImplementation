# InventoryTestImplementation

###Getting started: 
To get started with the React application it need to get the basepath set in the appsettings.development.json. The inventory and product files are committed in the repository in the common project. 
To get the api running you need to set the basepath in local.development.json

##Improvements: 
- Using an action/method-based solution is not a good nor safe solution since several overwrites can happen at the same time.  A more suitable solution if proceeding with method-based would be to use a data store that has the ability to lock the row while writing  My recommendation would be to instead use a eventbased pattern and PubSub 
- There is still a lot of NotImplementedException that would need to be implemented. 
- Some kind of API documentation like e.g. Swagger
- Logging has not yet been implemented (More than the default from Azure function that should catch all major errors) 
- Unit testing has been started but not yet finished. 
- Authorization level is currently set to allow all, should be raised to API key at least 
- Move away from the current data store of file on a disk and at least move to a blob. My recommendation would currently be Azure table due to the low complexity of the data. 
- Still a lot of potential null-exceptions these should be handle, maybe/options pattern would be a great first step

##Missing features
- Still missing ability to update any products other than selling. 