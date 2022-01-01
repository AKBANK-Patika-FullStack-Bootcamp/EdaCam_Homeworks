# EdaCam_Homeworks
This repo was created for Eda Çam's assignments in Akbank Full Stack Bootcamp.

## Week 1
A Web API has been designed in which CRUD operations of a product containing **id**, **name**, **price**, **brand**, **barcode**, **weight**, **expiry date** information are carried out.
This Web API has the features of;
- Listing products, 
- Displaying the product related to the product's id information, 
- Adding a new product to the system, 
- Updating the product related to the product's id information,
- Deleting the product related to the product's id information from the system.

## Week 2
The API has been tested using Postman, an API platform for the designed Web API, and screenshots of the relevant test results have been added.

- As a result of the product listing request, the response received by calling the method that brings the products in the system.

![GetProducts](https://user-images.githubusercontent.com/54909611/147854903-6a979eb7-216d-4280-b1fe-d1be67726885.JPG)

- As a result of the request to fetch the product related to the product id given as a parameter, the response received by calling the method that brings the product with the id in the system.

![GetProduct](https://user-images.githubusercontent.com/54909611/147854855-54ce2382-4dad-4d17-a024-f63eee6ffb77.JPG)

- In order to add a new product, the new product information in json format added to the body as a parameter, and the response returned by calling the method that returns the **Result** object as a response and displays the **request status**, **message** and the **current product list** in the system as response of the addition process.

![SaveProductSuccess](https://user-images.githubusercontent.com/54909611/147854981-dd799ba0-7793-4497-921a-9afa17bd1eb5.JPG)

- In order to add a new product, the product information with the previously existing idy in the system is added to the body as a parameter, the new product information in json format, and as a result of the addition process, the Result object is returned as a response and the request status (failed), the message (this product already exists) and the system The response returned by calling the method that displays the current product list (no new products added).

![SaveProductUnsuccess](https://user-images.githubusercontent.com/54909611/147855045-0693cee2-0cde-4185-8102-003b48ad092b.JPG)

- In order to update the product, the id information of the product with the existing id in the system is added to the endpoint and the current product information is added as a parameter to the body, the current product information in json format, and the method that returns the Result object as a response and shows the request status, message and the current product list in the system as a result of the update process. The response returned by the call.
![UpdateProductSuccess](https://user-images.githubusercontent.com/54909611/147855119-618ca0de-a351-4dd4-802b-5bf06dbb5d62.JPG)

- In order to update the product, the id information of the product with an id that did not exist in the system before, and the current product information in the endpoint and the current product information as a parameter to the body, is the current product information in json format, and as a result of the update process, it returns the Result object and the request status **(failed)**, the message **(this product is not in the system)**. and the response returned by calling the method that displays the current product list **(unchanged)** in the system.

![UpdateProductUnSuccess](https://user-images.githubusercontent.com/54909611/147855143-d13aa905-4ddb-4d5e-ab8e-08971c3191a8.JPG)

- To delete the product, the response is the method that adds the id information of the product with an **existing** id in the system as a parameter to the endpoint and returns the Result object as a response after the deletion process and displays the request status, message and the current product list in the system **(the product has been deleted)**.

![DeleteProductSuccess](https://user-images.githubusercontent.com/54909611/147855202-c77d26ff-caa4-4aa1-91b4-1a1edb319c80.JPG)

- To delete the product, the id information of the product with the existing id in the system is added as a parameter to the endpoint, and the response is returned by calling the method that returns the Result object as a response after the deletion process and displays the request status, message and the current product list in the system **(the product has been deleted)**.

![DeleteProductSuccess](https://user-images.githubusercontent.com/54909611/147855202-c77d26ff-caa4-4aa1-91b4-1a1edb319c80.JPG)

- In order to delete the product, by calling the method that adds the id information of the product with an id that does **not exist** in the system as a parameter to the endpoint and returns the Result object as a response after the deletion process and displays the request status (failed), the message (the product has already been deleted) and the current product list in the system **(the product is not deleted)**. returning reply.

![DeleteProductUnsuccess](https://user-images.githubusercontent.com/54909611/147855264-61ac024d-5c7e-4878-bdeb-d2a1a404b280.JPG)

