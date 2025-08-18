import axios from 'axios';
import React, {Component, useState} from 'react';

const EmployAdd = () => {
   const [data, setData] = useState({
        empno : 0, 
        name : '',
        gender : '',
        dept : '',
        desig : '',
        basic : 0
    })
    const [headAdd,setheadAdd] = useState("Employe status")
    const addEmploy = () => {
          setheadAdd("Employ status: Added succesfully");
      axios.post("https://localhost:7159/api/Employs/",{
        empno : data.empno,
        name : data.name,
        gender : data.gender,
        dept : data.dept,
        desig : data.desig,
        basic : data.basic
      }).then(resp => {
          //alert(resp.data);
          //alert("Employ Add successfully")
        
          console.log(resp.data);
        })

    }

    const handleChange = event => {
        setData({
            ...data,[event.target.name] : event.target.value  
        })
    }

     return (
    <div>
      
            <label>Employ Number : </label>
            <input type="number" name="empno" 
                value={data.empno} onChange={handleChange} /> <br/><br/>
            <label>Employ Name : </label>
            <input type="text" name="name" 
                value={data.name} onChange={handleChange} /> <br/><br/> 
            <label>Employ Gender : </label>
            <input type="text" name="gender" 
                value={data.gender} onChange={handleChange} /> <br/><br/> 

            <label>Employ Department : </label>
            <input type="text" name="dept" 
                value={data.dept} onChange={handleChange} /> <br/><br/> 
            <label>Employ Designation : </label>
            <input type="text" name="desig" 
                value={data.desig} onChange={handleChange} /> <br/><br/> 
            <label>Basic </label>
            <input type="number" name="basic" 
                value={data.basic} onChange={handleChange} /> <br/><br/> 
            <input type="button" value="Add Employ" onClick={addEmploy} /> 
            <h1>{headAdd}</h1>
    </div>
  )


}
export default EmployAdd;