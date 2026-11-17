// "use strict";
// Object.defineProperty(exports, "__esModule", { value: true });
// function greet(name) {
//     return `Hello ${name}`;
// }
// console.log(greet("kalpana"));
//# sourceMappingURL=practice.js.map


function ReverseString(str) {
  // Write your code here
  str = str.split("").reverse().join("");
  return str;
}

// Test cases
console.log(ReverseString("hello"));
console.log(ReverseString("Coderbyte"));


function FirstFactorial(num) {
   let fac=1;
   for(let i=num;i>=1;i--)
   {
    fac=fac*i;
   }
   return fac;
}

console.log(FirstFactorial(4));
console.log(FirstFactorial(5));


function FindLargest(arr) {
  // Write your code here
  let max = arr[0];
  for(let i=1;i<arr.length;i++)
  {
    if(arr[i]>max)
    {
        max=arr[i];
    }
  }

  return max;
}

console.log(FindLargest([4, 8, 2, 10, 5]));
console.log(FindLargest([15, 3, 25, 7]));


function SecondLargest(arr) {
  // Write your code here
  let max = INT_MIN;
  let secondmax = INT_MIN;
  for(let i =0;i<arr.length;i++)
  {
    if(arr[i]>max)
    {
        secondmax = max;
        max = arr[i];
    }
    if(arr[i]<max&&arr[i]>secondmax)
    {
        secondmax = arr[i];
    }
  }
  return max == secondmax ? -1 : secondmax
}

console.log(SecondLargest([10, 5, 8, 20, 15]));
console.log(SecondLargest([5, 5, 4, 3]));
console.log(SecondLargest([10, 10, 10]));




function FirstNonRepeating(str) {
  // Write your code here
  const freq = new Map();
  for(const char of str)
  {
    freq.set(char,(freq.get(char)||0)+1);
  }
  
  for(const [key,value] of freq)
  {
    if(value==1)
    {
       return key
    }
  }
  return -1
}


console.log(FirstNonRepeating("aabbcde"));
console.log(FirstNonRepeating("hello"));
console.log(FirstNonRepeating("aabb"));


function TwoSum(arr, target) {
  // Write your code here
  const st = new Map();
  for(let i =0;i<arr.length;i++)
  {
    if(st.has(target-arr[i]))
    {
        return [st.get(target-arr[i]),i]
    }

    st.set(arr[i],i);
  }
   return -1
}

console.log(TwoSum([2, 7, 11, 15], 9));
console.log(TwoSum([3, 2, 4], 6));
console.log(TwoSum([3, 3], 6));



function CreateCounter() 
{
   let count = 0;
   return function() {
    count++;
    return count;
   }
  
}

const counter = CreateCounter();

console.log(counter());
console.log(counter());
console.log(counter());
console.log(counter());



function GetTotalSalary(employees) 
{
  return employees.filter(emp => emp.salary >= 30000).reduce((sum,emp)=>sum+emp.salary,0)
}

console.log(GetTotalSalary(employees));


async function getUser() {
  try {
    const resp = await fetch("https://jsonplaceholder.typicode.com/users/1");


    if (!resp.ok) {
      throw new Error("Not found");
    }

    const data = await resp.json();
    return data.name; 
  } catch (err) {
    throw err;
  }
}

getUser()
  .then(name => console.log(name)) 
  .catch(err => console.error(err.message));



const employee = {
  name: "Kalpana",
  salary: 50000,

  getBonus: function() {
    return this.salary/10;
  }
};

console.log(employee.getBonus());


function MergeUsers(user1, user2) {
  const user3 = {...user1,...user2}
  return user3;

}

console.log(MergeUsers(user1, user2));



function CustomMap(arr, callback) {
  // Write your code here
  let res = new Array();
  arr.forEach(element => {
    res.push(callback(element));
    
  });
  return res;
}

const numbers = [1, 2, 3, 4];

const result = CustomMap(numbers, function(num) {
  return num * 2;
});

console.log(result);
console.log(numbers);



function ProcessNumbers(arr) {
  arr = arr.filter(ele=>ele%2==0).map(ele=>ele*ele);
  const unis = new Set(arr);
  arr = [...unis]
  return arr

}

console.log(ProcessNumbers([1, 2, 2, 3, 4, 4, 5, 6]));









