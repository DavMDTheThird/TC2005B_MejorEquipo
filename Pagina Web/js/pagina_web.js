function main()
{
    //----------------------
    document.getElementById('formSelectCompleatedGames').onsubmit = async (e) =>
    {
        e.preventDefault()

        // Clear the container
        const container = document.getElementById('getResultsID')
        container.innerHTML = '<canvas id = "charts"></canvas>'

        const data = new FormData(formSelectCompleatedGames)
        const dataObj = Object.fromEntries(data.entries())

        console.log(dataObj)

        let response = await fetch(`/api/user_maxWins`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json()

            //Informacion recolectada:
            const id_usuario = results.map(item => item.nombre);
            const gamesWon = results.map(item => item.juegos_completados);
  
            // Create Chart.js bar chart
            var ctx = document.getElementById('charts').getContext('2d');
  
            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: id_usuario,
                    datasets: [{
                        label: 'Total Games Compleated',
                        data: gamesWon,
                        backgroundColor: 'rgba(0, 123, 255, 0.75)'
                    }]
                },
                options: {
                    scales: {
                    y: {
                        beginAtZero: true
                    }},
                    aspectRatio: 2
                }
            });
        
        }
        else{
            getResults.innerHTML = response.status
        }
    }


    document.getElementById('formSelectMobKills').onsubmit = async (e) =>
    {
        e.preventDefault()

        const data = new FormData(formSelectMobKills)
        const dataObj = Object.fromEntries(data.entries())

        console.log(dataObj)

        let response = await fetch(`/api/mobs_mostKills`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            // Clear the container
            const container = document.getElementById('getResultsID')
            container.innerHTML = '<canvas id = "charts"></canvas>'

            let results = await response.json()

            //Informacion recolectada:
            const mob_name = results.map(item => item.nombre_enemigo);
            const timesKilled = results.map(item => item.asesinatos);
  
            // Create Chart.js bar chart
            var ctx = document.getElementById('charts').getContext('2d');
  
            var chart = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: mob_name,
                    datasets: [{
                        label: 'Total Games Compleated',
                        data: timesKilled,
                        backgroundColor: [
                            'rgb(255, 99, 132)',
                            'rgb(54, 162, 235)',
                            'rgb(255, 205, 86)',
                            'rgb(153, 102, 255)',
                            'rgb(75, 192, 192)'
                          ],
                        hoverOffset: 1
                    }]
                },
                options: {
                    aspectRatio: 2,
                    plugins: {
                        title: {
                          display: true,
                          text: 'Enemigos que más han acabado al personaje',
                          font: {
                            size: 25,
                            weight: 'bold',
                            family: Chart.defaults.font.family
                          }
                        }
                      }
                }
            });
        
        }
        else{
            getResults.innerHTML = response.status
        }
    }

    document.getElementById('formSelectUserGeek').onsubmit = async (e) =>
    {
        e.preventDefault()

        // Clear the container
        const container = document.getElementById('getResultsID')
        container.innerHTML = '<canvas id = "charts"></canvas>'

        const data = new FormData(formSelectUserGeek)
        const dataObj = Object.fromEntries(data.entries())

        console.log(dataObj)

        let response = await fetch(`/api/user_masViciados`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json()

            //Informacion recolectada:
            const usuario = results.map(item => item.nombre);
            const horas = results.map(item => item.horas_jugadas);
  
            // Create Chart.js bar chart
            var ctx = document.getElementById('charts').getContext('2d');
  
            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: usuario,
                    datasets: [{
                        data: horas,
                        // label: 'Horas',
                        backgroundColor: ['rgb(31, 119, 180)',
                        'rgb(255, 127, 14)',
                        'rgb(44, 160, 44)',
                        'rgb(214, 39, 40)',
                        'rgb(148, 103, 189)',
                        'rgb(140, 86, 75)',
                        'rgb(227, 119, 194)',
                        'rgb(127, 127, 127)',
                        'rgb(188, 189, 34)',
                        'rgb(23, 190, 207)']
                    }]
                },
                options: {
                    indexAxis: 'y',
                    scales: {
                    x: {
                        beginAtZero: true
                    }},
                    aspectRatio: 2,
                    plugins: {
                        title: {
                          display: true,
                          text: 'Top 10 usuarios con mas horas totales jugadas',
                          font: {
                            size: 25,
                            weight: 'bold',
                            family: Chart.defaults.font.family
                          }
                        }
                      },
                      legend: {
                        display: false
                      }
                }
            });
        
        }
        else{
            getResults.innerHTML = response.status
        }
    }


    //----------------------
    document.getElementById('formSelectUserMasMalo').onsubmit = async (e) =>
    {
        e.preventDefault()

        // Clear the container
        const container = document.getElementById('getResultsID')
        container.innerHTML = '<canvas id = "charts"></canvas>'

        const data = new FormData(formSelectUserMasMalo)
        const dataObj = Object.fromEntries(data.entries())

        console.log(dataObj)

        let response = await fetch(`/api/user_masMalo`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json()

            //Informacion recolectada:
            const id_usuario = results.map(item => item.nombre);
            const muertes = results.map(item => item.muertes_totales);
  
            // Create Chart.js bar chart
            var ctx = document.getElementById('charts').getContext('2d');
  
            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: id_usuario,
                    datasets: [{
                        // label: 'Total Games Compleated',
                        data: muertes,
                        backgroundColor: ['rgb(127, 127, 127)',
                        'rgb(140, 86, 75)',
                        'rgb(214, 39, 40)',
                        'rgb(148, 103, 189)',
                        'rgb(188, 189, 34)',
                        'rgb(31, 119, 180)',
                        'rgb(227, 119, 194)',
                        'rgb(255, 127, 14)',
                        'rgb(44, 160, 44)',
                        'rgb(23, 190, 207)']
                    }]
                },
                options: {
                    scales: {
                    y: {
                        beginAtZero: true
                    }},
                    aspectRatio: 2
                }
            });
        
        }
        else{
            getResults.innerHTML = response.status
        }
    }
}

main()