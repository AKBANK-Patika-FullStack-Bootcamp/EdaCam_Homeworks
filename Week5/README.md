## Week 5
- To be authorized, users must be **registered** in the system then registered users must **create tokens** by **login** to perform authorized operations on the system.
- APIAuthority table was created in the database for the user create-login operation.
![image](https://user-images.githubusercontent.com/54909611/150584632-5c88fe9f-bb21-42ac-a736-6206dd798757.png)

- APIAuthority, Login and LoginDTO classes have been created in the DAL package for user and token operations.
- In the **AuthController** class, the LoginCreate and Login methods create user records in the database and create Tokens with user login.
- While the user is registered, the password of the user is **hashed** and saved in the database with the help of MD5CryptoServiceProvider.
 ![image](https://user-images.githubusercontent.com/54909611/150586218-153a3a57-baf6-4138-8543-cf0f6f50a03a.png)

- If the user information in the database matches during login, a token is generated with the JwtSecurityToken and JwtSecurityTokenHandler methods offered by the Jwt package.
![image](https://user-images.githubusercontent.com/54909611/150586350-1b0401f3-9828-442d-b0d2-ae235c567817.png)
![image](https://user-images.githubusercontent.com/54909611/150586528-4f84c1aa-3837-4d53-8487-a7e17a85d649.png)

- **Tokenless** response to a request that allows access by authorized users
![image](https://user-images.githubusercontent.com/54909611/150586899-fcb143cc-fbc8-41bb-bf98-44fdb93ab0b3.png)

- Response to a request that allows authorized users to access it **with a token**
![image](https://user-images.githubusercontent.com/54909611/150587223-e04722da-f4a0-41a1-bcbd-2b1372ff1ade.png)

- The PagingParameters object is used as a parameter for the paging process and the products are paginated with the Skip(), Take() methods.
- In addition, the usability of this request by users with tokens has been tested. It is an authorized request too.
- Pagination operation was done by ordering products according to the product names.
![image](https://user-images.githubusercontent.com/54909611/150588063-fdda5078-a809-4502-85d5-a9a502884aa8.png)
