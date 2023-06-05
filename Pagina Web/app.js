"use strict"

import express from 'express'
import mysql from 'mysql2/promise'
import fs from 'fs'

const app = express()
const port = 5000

app.use(express.json())
app.use(express.static('./'))

async function connectToDB()
{
    return await mysql.createConnection({
        host:'localhost',
        user:'test_API',
        password:'Hola_123',
        database:'darkesttimes'
    })
}

app.get('/', (request,response)=>{
    fs.readFile('./html/index.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
})

//------------------------------ Busqueda de usuario con mas veces superado el juego ------------------------------
app.get('/api/user_maxWins', async (request, response)=>{
    let connection = null  //This variable will be used to hold the database connection object.

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('SELECT usuario, Juego_completado FROM darkesttimes.usuario ORDER BY Juego_completado DESC LIMIT 5;')//La busqueda

        console.log(`${results.length} rows returned`)
        console.log(results)
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
//------------------------------ Busqueda de mobs con mas muertes causadas ------------------------------
app.get('/api/mobs_mostKills', async (request, response)=>{
    let connection = null  //This variable will be used to hold the database connection object.

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('SELECT nombre, asesinatos FROM darkesttimes.enemigo ORDER BY asesinatos DESC LIMIT 5;')//La busqueda

        console.log(`${results.length} rows returned`)
        console.log(results)
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
//------------------------------ Busqueda de usuarios con mas tiempo gastado jugando ------------------------------
app.get('/api/user_mostGeek', async (request, response)=>{
    let connection = null  //This variable will be used to hold the database connection object.

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('SELECT usuario, horas_jugadas FROM darkesttimes.usuario ORDER BY horas_jugadas DESC LIMIT 10;')//La busqueda

        console.log(`${results.length} rows returned`)
        console.log(results)
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
//------------------------------ Busqueda de usuarios con mas easter eggs ------------------------------
app.get('/api/user_easterEggs', async (request, response)=>{
    let connection = null  //This variable will be used to hold the database connection object.

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('SELECT usuario, easter_eggs FROM darkesttimes.usuario ORDER BY easter_eggs DESC LIMIT 10;')//La busqueda

        console.log(`${results.length} rows returned`)
        console.log(results)
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//////////////
//Videojuego//------------------------------------------------------------------------------------------
/////////////

app.get('/api/juego/checkpoint', async (request, response)=>{
    let connection = null  //This variable will be used to hold the database connection object.

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('SELECT usuario, easter_eggs FROM darkesttimes.usuario ORDER BY easter_eggs DESC LIMIT 1;')//La busqueda

        console.log(`${results.length} rows returned`)
        console.log(results)
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})







//------------------------------ Ejemplos ------------------------------
/*app.get('/api/user/', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results_user, _] = await connection.query('select * from users where id_users= ?', [request.params.id])
        
        //console.log(`${results_user.length} rows returned`)
        response.json(results_user)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})*/

/*app.post('/api/users', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into users set ?', request.body)
        
        //console.log(`${results.affectedRows} row inserted`)
        response.json({'message': "Data inserted correctly.", "id": results.insertId})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})*/

/*app.put('/api/users', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()

        const [results, fields] = await connection.query('update users set name = ?, surname = ? where id_users= ?', [request.body['name'], request.body['surname'], request.body['userID']])
        
        console.log(`${results.affectedRows} rows updated`)
        response.json({'message': `Data updated correctly: ${results.affectedRows} rows updated.`})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})*/

/*app.delete('/api/users/:id', async (request, response)=>{

    let connection = null

    try
    {
        connection = await connectToDB()

        const [results, fields] = await connection.query('delete from users where id_users= ?', [request.params.id])
        
        console.log(`${results.affectedRows} row deleted`)
        response.json({'message': `Data deleted correctly: ${results.affectedRows} rows deleted.`})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})*/

app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`)
})