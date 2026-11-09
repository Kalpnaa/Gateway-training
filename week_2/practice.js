const data = '{"name":"Kalpana","age":21}';

const studentObject = JSON.parse(data);

console.log(studentObject);

const studentstring = JSON.stringify(studentObject);

console.log(studentstring)