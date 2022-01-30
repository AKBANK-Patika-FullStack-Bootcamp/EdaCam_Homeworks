# Week 6
## Part 1 -export/import
- The kopek.js file was created and a dog object (containing the dog's name-length-weight values) was defined in kopek.js.
- The kopekBakımUtility.js file was created and the kopegiTemizle method was written in kopekBakımUtility. This method prints the message "kopeginiz yikandi" to the console.
- A kopekBakimSaati constant has been registered in kopekBakımUtility ( as 4 ).
- Both dog and kopekBakımUtility are imported in app.js. **module.exports={..}** used for this operation.
- In app.js, the dog's name, height,"kopeginiz yikandi" and the kopekBakimSaati values were printed to the console. **Multiline string** is used for printing to the console in a single line these values.

![Part1Çıktı](https://user-images.githubusercontent.com/54909611/151712762-6f8ecf7c-6e51-4183-9ffb-a57ba16202db.JPG)

## Part 2
- The girslPowerToplam function is defined that adds 3 to half of the given number.
- The girlsPower function takes a function and an array as parameters.It maps this array and calls the parameter function in its items. So the girlsPower function is a high order function.
- Returns the updated array as a result.
- Input Array:[2,3,4]
- Output:
 ![Part2Çıktı](https://user-images.githubusercontent.com/54909611/151713031-089082db-d009-4466-9038-e480346ecbd6.JPG)

## Part 3
- The inverse of the given string is formed by 6 methods.
- String methods, Array methods and Loops are used.
1. The string is first split with the split method, then the position of the elements is reversed and joined with join.
2. The string is copied, then the elements are reversed and joined with a join.
3. The indexes of the string are read backwards and added to an empty string with +.
4. The indexes of the string are read backwards and pushed into an array, combined with the join method.
5. By using the reduce method, iterations were collected by writing to the left.
6. By using the reduceRight method, iterations are made to start from the end of the string.

* I think the most appropriate method is the reduce method because it does not require extra processing since it is a less complex structure.
We can copy our string and get its updated (reverse) version only by using the reduce method.
- Input:Eda
- Output:
<br> ![Part3Çıktı](https://user-images.githubusercontent.com/54909611/151713426-a5c25809-af03-4e6d-8168-a39c2632c510.JPG)
