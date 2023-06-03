function main()
{
    document.getElementById('formSelectUser').onsubmit = async (e) =>
    {
        e.preventDefault()

        const data = new FormData(formSelectUser)
        const dataObj = Object.fromEntries(data.entries())

        console.log(dataObj)

        let response = await fetch(`http://localhost:5000/api/user_maxWins`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json()
        
            /*if(results.length > 0)
            {
                const headers = Object.keys(results[0])
                const values = Object.values(results)
    
                let table = document.createElement("table")
    
                let tr = table.insertRow(-1)                  
    
                for(const header of headers)
                {
                    let th = document.createElement("th")     
                    th.innerHTML = header
                    tr.appendChild(th)
                }
    
                for(const row of values)
                {
                    let tr = table.insertRow(-1)
    
                    for(const key of Object.keys(row))
                    {
                        let tabCell = tr.insertCell(-1)
                        tabCell.innerHTML = row[key]
                    }
                }
    
                const container = document.getElementById('getResultsID')
                container.innerHTML = ''
                // container.appendChild(table)
            }
            else
            {
                const container = document.getElementById('getResultsID')
                container.innerHTML = 'No results to show.'
            }*/
        }
        else{
            getResults.innerHTML = response.status
        }
    }

}

main()