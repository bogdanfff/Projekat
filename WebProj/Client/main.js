import { Crtaj } from "./Crtaj.js";
import { Muzej } from "./Muzej.js";


const listaMuzeja = [];
fetch("https://localhost:5001/Muzej/PrikaziMuzej")
.then(p=>{

    p.json().then(q =>{

        q.forEach(muzej => {

            var g = new Muzej(muzej.id, muzej.naziv);
            listaMuzeja.push(g);
            
            
        });

        var c = new Crtaj(listaMuzeja);
        c.pocetna(document.body);
    })

})


