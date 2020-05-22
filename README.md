# OnlineStore
An online store developed using C#

Notes for the Products Branch:
1) The PUT POST GET DELETE Methods all have the same route of "products/" and are differentiated by the Methods themselves as sent by the front end. This is to keep up with REST standards. Having them named as by their method names is more SOAP like accoridng to what I have read.

2) I made use of the Singleton Pattern to hold an instance of the Products In Memory Data Store. The Data Store is wrapped up in ProductAccessor which is like a DBMS in this case, which is the service we would like to pass to the controller. I used dependency injection to pass the service to the controller's constructor, as a singleton.

3) Did not do any exception handling yet in the controllers. They all return STATUS 200 for now.

4) I am not persisting the data back to the json file when the server is closed. Do not know if we need to. We can always just have a default number of products in the products.json file. So far it has 1 such default product.

5) Does not work on PostMan yet for some reason, but works through SWAGGER.

6) Requests:
addProduct has a request body as follows:
{
  "productName": "",
  "productDescription": "",
  "price": 0,
  "userID": 0
}

updateProduct must be sent a url parameter of 'id' to identify the resource in the server and the request body is the same as addProduct.

7) Responses:
getProduct has response as follows, for a particular product id which we requested for:
{
  "results": {
    "productID": 1,
    "productName": "asdf",
    "productDescription": "asdf",
    "price": 5,
    "userID": 7
  }
}

User Admin setup 
1)change connection string in appsettings.json
2)run "update-database --verbose" on package manager console and create UserView, sql has been added.
