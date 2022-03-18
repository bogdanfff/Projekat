import { Muzej } from "./Muzej.js";
import { Karte } from "./karte.js";
import { Predmeti } from "./predmeti.js";

export class Crtaj{

    constructor(listaMuzeja,listaPredmeta){
        
        this.listaMuzeja = listaMuzeja;
        this.kontejner = null;
        this.listaPredmeta=listaPredmeta;
    }
    obrisi(host){
        if(this.kontejner != null){
            while (this.kontejner.lastChild) {
                this.kontejner.removeChild(this.kontejner.lastChild);
            }
        }
        while (host.lastChild) {
            host.removeChild(host.lastChild);
        }
    }

    pocetna(host){
        
        
        let header = document.createElement("div");
        header.className="header";
        host.appendChild(header);
        
        let naslov = document.createElement("label")
        naslov.innerHTML = "muzeji </br> sveta";
        naslov.className ="naslov";
        header.appendChild(naslov);

        let lista = document.createElement("div")
        lista.className ="lista";

        header.appendChild(naslov);

        let muzeji = document.createElement("div")
        muzeji.className ="muzeji";
        header.appendChild(muzeji);
        
        this.listaMuzeja.forEach(element => {
            const m =new Muzej();
            m.id=element.id
            m.naziv=element.naziv
            m.Muzej(muzeji);
        });
        this.kontejner = document.createElement("div");
        this.kontejner.className = "Glavna";
        host.appendChild(this.kontejner);
        this.poc(this.kontejner);
        header.appendChild(lista);
        let k=document.createElement("div");
        k.innerHTML="karte";
        k.className="karta"
        header.appendChild(k);
        k.onclick = (ev) => this.karta(this.kontejner);

        let s=document.querySelectorAll(".muzej")
        s.forEach(e=>{
            e.onclick= (ev) => this.muzeji(e.innerHTML,this.kontejner);
        })
        
        naslov.onclick= (ev) => this.poc(this.kontejner);
    }
    poc(host){
        this.obrisi(host);
        let p = document.createElement("h1");
        p.innerHTML="<i>HOME PAGE<i>";
        host.appendChild(p);
    }
    karta(hostt){
        this.obrisi(hostt);
        let host=document.createElement("div")
        hostt.appendChild(host)
        host.className="prva"
        let druga=document.createElement("div")
        hostt.appendChild(druga)
        druga.className="druga";

        let l = document.createElement("div")
        l.className ="labele";
        let la = document.createElement("div")
        la.className ="labele2";
        let ra = document.createElement("div")
        ra.className ="radio";
        let f = document.createElement("div")
        f.className ="radioLabele";

        host.appendChild(l);
        host.appendChild(f);
        f.appendChild(la);
        f.appendChild(ra);

        let i=document.createElement("label");
        i.innerHTML="Ime";
        let ime=document.createElement("input");
        ime.type="text";
        ime.className="ime";
        let p=document.createElement("label");
        p.innerHTML="Prezime";
        let prezime=document.createElement("input");
        prezime.type="text";
        let m=document.createElement("label");
        m.innerHTML="Muzej";
        let muzej=document.createElement("select");
        muzej.className="forme";
        ime.className="forme";
        prezime.className="forme";

        let b=document.createElement("button");
        b.innerHTML="Submit";
        b.style.marginTop="20px"
        b.className="forme";

        let nizRbt=["Nova","Brisi","Izmena"];
        nizRbt.forEach(el=>{
            let lab=document.createElement("label");
            lab.innerHTML=el;
            lab.className="radioLabele";
            la.appendChild(lab);
        });
        
        nizRbt.forEach((el,index)=>{
           
            let rad=document.createElement("input");
            rad.type="radio";
            rad.className="r";
            rad.value=index;
            rad.name="rad"
            if(index===0){rad.checked=true}
            ra.appendChild(rad);
        });

        var j=0;
        let listaRb=document.querySelectorAll(".r")
        listaRb[0].onclick=function nesto(){muzej.style.cursor="auto";ime.style.cursor="auto";prezime.style.cursor="auto";muzej.disabled=false;ime.disabled=false;prezime.disabled=false;
            brojrezervacije.className="rezervacijaN"
            r1.className="rezervacijaN"
        }
        

        listaRb[1].onclick=function nesto2(){muzej.style.cursor="not-allowed";ime.style.cursor="not-allowed";prezime.style.cursor="not-allowed";muzej.disabled=true;ime.disabled=true;prezime.disabled=true;
                r1.innerHTML="Unesite broj rezervacije";
                brojrezervacije.className="rezervacijaD"
                r1.className="rezervacijaD"
            
        }
        listaRb[2].onclick=function nesto3(){muzej.style.cursor="auto";ime.style.cursor="auto";prezime.style.cursor="auto";muzej.disabled=false;ime.disabled=false;prezime.disabled=false;
            r1.innerHTML="Unesite broj rezervacije";
            brojrezervacije.className="rezervacijaD"
                r1.className="rezervacijaD"
        }

        let r1=document.createElement("label");
        r1.className="rezervacijaN"
        var brojrezervacije=document.createElement("input");
        brojrezervacije.type="number";
        brojrezervacije.className="rezervacijaN";

        l.appendChild(r1);
        l.appendChild(brojrezervacije);
        
        l.appendChild(i);
        l.appendChild(ime);
        l.appendChild(p);
        l.appendChild(prezime);
        l.appendChild(m);
        l.appendChild(muzej);
        l.appendChild(b);

       
        let op;
        this.listaMuzeja.forEach(el=>{
            op = document.createElement("option");
            op.innerHTML=el.naziv;
            op.value=el.id;
            muzej.appendChild(op);
        })

        let prikaz = document.querySelector(".desna");
        let uneto=document.createElement("div");
        druga.appendChild(uneto)

        let h2 = document.createElement("h2");
        h2.className = "headerGlavne";
        uneto.appendChild(h2);

        let brRezervacije = document.createElement("div");
        brRezervacije.className = "brRezervacije";
        uneto.appendChild(brRezervacije);
    
        let kIme = document.createElement("div");
        kIme.className = "kIme";
        uneto.appendChild(kIme);
    
        let kPrezime = document.createElement("div");
        kPrezime.className = "kPrezime";
        uneto.appendChild(kPrezime);
    
        let kMuzejNaziv = document.createElement("div");
        kMuzejNaziv.className = "kMuzejNaziv";
        uneto.appendChild(kMuzejNaziv);

        let but=document.createElement("button");
        but.className="nazad";
        uneto.appendChild(but);
        but.onclick = (ev) => this.karta(hostt);
        
        
            b.onclick = (ev) =>{ 
                let rbt = document.querySelector("input[type='radio']:checked").value
                if(rbt==0){
                    if(ime.value.length>0 && prezime.value.length>0 &&ime.value.length<50 && prezime.value.length<50)
                    {
                this.dodajKartu(ime.value,prezime.value);}
                else{alert("Pogresan unos podataka")}
            
            }
            else if(rbt==1){
                this.obrisiKartu(brojrezervacije.value);
    
            }
            else{
                let optionE2 = this.kontejner.querySelector("select");
                const muz=optionE2.options[optionE2.selectedIndex].innerHTML;
                if(ime.value.length>0 && prezime.value.length>0 &&ime.value.length<50 && prezime.value.length<50){
                this.izmeniKartu(brojrezervacije.value,ime.value,prezime.value,muz);}
            }}
    }

    izmeniKartu(br,ime,prezime,muzej){
        fetch("https://localhost:5001/Karte/IzmeniKartu/" + br + "/" + ime + "/" + prezime + "/" + muzej,{
            method:"PUT"
        })
        .then(s=>{
            if(s.ok){
                s.json().then( data =>{
                    var k1 = new Karte(data[0].ime, data[0].prezime, data[0].muzej,data[0].brojRezervacije);
                        var ka = new Karte(ime, prezime,muzej,br);
                        this.kontejner.removeChild(this.kontejner.firstElementChild);
                        ka.crtaj3(k1);
                    

                    
                })
            }
            else{

                alert("Uneti podaci nisu validni");
            }


        })
    }
    


    obrisiKartu(brrez){
        fetch("https://localhost:5001/Karte/ObrisiKartu/" + brrez, {
            method:"DELETE"
        })
        .then(s=>{
            if(s.ok){
                s.json().then( data =>{
                    
                        var ka = new Karte(data[0].ime, data[0].prezime, data[0].muzej,data[0].brojRezervacije);
                        this.kontejner.removeChild(this.kontejner.firstElementChild);
                        ka.crtaj2();
                    

                    
                })
            }
            else{

                alert("Uneti podaci nisu validni");
            }


        })
    }
    dodajKartu(ime,prezime){
        let brRez =Math.floor(Math.random()*90000)+10000;

        let optionEl = this.kontejner.querySelector("select");
        var muzejId = optionEl.options[optionEl.selectedIndex].value;
        fetch("https://localhost:5001/Karte/DodajKartu/" + ime + "/" + prezime + "/" + muzejId + "/" + brRez, {
            method:"POST"
        })
        .then(s=>{
            if(s.ok){
                s.json().then( data =>{
console.log(data)
                    var k = new Karte(data[0].ime, data[0].prezime, data[0].muzej, data[0].brojRezervacije);
                    this.kontejner.removeChild(this.kontejner.firstElementChild);
                    k.crtaj();

                })
            }
            else{

                alert("Uneti podaci nisu validni");
            }


        })
        
    }
    muzeji(muzejNaziv,host){
        this.obrisi(host);
        let levo=document.createElement("div");
        levo.className="levo";
        let desno=document.createElement("div");
        desno.className="desno";
        let dodaj=document.createElement("h3");
        dodaj.innerHTML="Svi predmeti muzeja "+muzejNaziv;
        host.appendChild(levo);
        host.appendChild(desno);
        levo.appendChild(dodaj);
        this.preuzmiPredmete(muzejNaziv,levo,desno)

        /*
        let slika=document.createElement("img");
        let a="Mona Lisa"
        slika.src="./images/"+a.replace(/ /g, "")+".jpg"
        console.log(slika.height);
        console.log(slika.width);
        levo.appendChild(slika);
        */
    }
    preuzmiPredmete(muzej,host,host2){
        this.prvi(host);
        fetch("https://localhost:5001/Predmet/PredmetiMuzeja/" + muzej,{
            method:"GET"
        })
        .then(p=>{

            p.json().then( predmeti =>{this.listaPredmeta=predmeti;

                predmeti.forEach( predmet => {
                    
                    

                    
                    let pr = new Predmeti(predmet.naziv, predmet.tip, predmet.godina, predmet.tvorac, predmet.era);
                    pr.crtaj(host);

                    let ss=document.querySelectorAll("td")
                        ss.forEach(e=>{
                            if(e.className=="ime"){
                            e.onclick= (ev) => this.slike(e.innerHTML,host2);}
                        })
                })
            })
        })
    }
    slike(el,host){
        let i=0;
        while(this.listaPredmeta[i].naziv !=el){i++;}
        if(host != null){
            while (host.lastChild) {
                host.removeChild(host.lastChild);
            }
        }
        let preview=document.createElement("h3");
        preview.innerHTML="Preview predmeta "+el;
        host.appendChild(preview)

        let ram=document.createElement("div");
        ram.className="ram";
        let slika=document.createElement("img");
        slika.src="./images/"+el.replace(/ /g, "")+".jpg";
        slika.className="slika";
        host.appendChild(ram);
        ram.appendChild(slika)

        let info1=document.createElement("div");
        info1.className="info";
        info1.innerHTML=this.listaPredmeta[i].godina+". godina "+this.listaPredmeta[i].era;
        ram.appendChild(info1);
        

    }
    prvi(host){
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var td = document.createElement("td");
        td.innerHTML = "Naziv";
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = "Tip";
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = "Tvorac";
        tr.appendChild(td);
    }
}