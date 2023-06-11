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
        database:'darkesttimes_bd'
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
        const [results, fields] = await connection.execute('SELECT * FROM usuarios_juegosGanados LIMIT 5;')//La busqueda

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
        const [results, fields] = await connection.execute('SELECT * FROM mobs_masAsesinatos LIMIT 5;')//La busqueda

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
app.get('/api/user_masViciados', async (request, response)=>{
    let connection = null  //This variable will be used to hold the database connection object.

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('SELECT * FROM usuario_viciado LIMIT 10;')//La busqueda

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
//------------------------------ Busqueda de usuarios mas muertes ------------------------------
app.get('/api/user_masMalo', async (request, response)=>{
    let connection = null  //This variable will be used to hold the database connection object.

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('SELECT * FROM usuario_masMalo LIMIT 10;')//La busqueda

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

app.post('/api/juego/addPersonaje', async (request, response)=>{

    let connection = null
    
    let personaje_request = request.body.personaje
    let vida_actual_request = request.body._hp
    let vida_max_request = request.body._maxhp
    let nivel_request = request.body._lvl
    let xp_request = request.body._xp
    let suerte_request = request.body._lck
    let ataque_request = request.body._atk
    let stamina_request = request.body._stamina
    let inventario_request = request.body._inventory
    let multiplicador_monedas_request = request.body._TimesMoney
    let monedas_request = request.body._money
    
    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('INSERT INTO personaje SET ?', {
            personaje: personaje_request,
            vida_actual: vida_actual_request,
            vida_max: vida_max_request,
            nivel: nivel_request,
            xp: xp_request,
            suerte: suerte_request,
            ataque: ataque_request,
            stamina: stamina_request,
            inventario: inventario_request,
            multiplicador_monedas: multiplicador_monedas_request,
            monedas: monedas_request,
            muertes: 0
          })      
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
})

app.post('/api/juego/addInventario', async (request, response)=>{

    let connection = null

    let pocionQM = request.body.pocionQM
    let escudoQM = request.body.escudoQM
    let antorchaQM = request.body.antorchaQM
    let linternaQM = request.body.linternaQM
    let mecheroQM = request.body.mecheroQM
    let bengala_gunQM = request.body.bengala_gunQM
    let ballesta = request.body.ballesta
    let espada = request.body.espada
    let bat = request.body.bat
    let staff = request.body.staff
    let rifle = request.body.rifle

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into inventario set ?', {
            pocionQM: pocionQM,
            escudoQM: escudoQM,
            antorchaQM: antorchaQM,
            linternaQM: linternaQM,
            mecheroQM: mecheroQM,
            bengala_gunQM: bengala_gunQM,
            ballesta: ballesta,
            espada: espada,
            bat: bat,
            staff: staff,
            rifle: rifle
          })
        
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
})

app.post('/api/juego/setCheckpoint', async (request, response)=>{

    let connection = null

    let id_usuario = request.body.id_usuario
    let id_personaje = request.body.id_personaje
    let id_inventario = request.body.id_inventario
    let id_nivel = request.body.id_nivel

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into checkpoints set ?', {
            id_usuario: id_usuario,
            id_personaje: id_personaje,
            id_inventario: id_inventario,
            id_nivel: id_nivel
          })
        
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
})

app.put('/api/juego/updateCheckpoint', async (request, response)=>{

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
})

app.get('/api/juego/getCheckpoint', async (request, response)=>{
    let connection = null  //This variable will be used to hold the database connection object.

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('SELECT personaje.* FROM darkesttimes_BD.checkpoints JOIN darkesttimes_BD.personaje ON darkesttimes_BD.checkpoints.id_personaje = darkesttimes_BD.personaje.id_personaje WHERE darkesttimes_BD.checkpoints.id_usuario = ? ORDER BY id_personaje DESC LIMIT 1;', [request.body['id']])

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

app.post('/api/juego/addUser', async (request, response)=>{

    let connection = null
    
    let nombre_request = request.body.nombre
    let correo_request = request.body.correo
    let contraseña_request = request.body.contraseña
    
    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('INSERT INTO usuarios SET ?', {
            nombre: nombre_request,
            correo: correo_request,
            contraseña: contraseña_request,
            horas_jugadas: 0,
            juegos_completados: 0,
            muertes_totales: 0
          });        
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