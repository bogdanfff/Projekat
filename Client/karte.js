export class Karte{

    constructor(ime, prezime,muzejNaziv,brojRezervacije){
        this.ime= ime;
        this.prezime = prezime;
        this.muzejNaziv = muzejNaziv
        this.brojRezervacije=brojRezervacije
        
    }

    crtaj(){
        let p = document.querySelector("h2");
        p.innerHTML = "<i>Uspesno kupljena karta<i>";

        p = document.querySelector(".kIme");
        p.innerHTML = "Ime posetioca: " + this.ime;

        p = document.querySelector(".kPrezime");
        p.innerHTML = "Prezime posetioca: " + this.prezime;

        p = document.querySelector(".kMuzejNaziv");
        p.innerHTML = "Naziv muzeja: " + this.muzejNaziv;

        p = document.querySelector(".brRezervacije");
        p.innerHTML = "Broj rezervacije: " + this.brojRezervacije;

        p = document.querySelector(".nazad");
        p.className="nazadd"
        p.innerHTML = "Nazad";


    }
    crtaj2(){
        let p = document.querySelector("h2");
        p.innerHTML = "<i>Uspesno obrisana karta<i>";

        p = document.querySelector(".kIme");
        p.innerHTML = "Ime posetioca: " + this.ime;

        p = document.querySelector(".kPrezime");
        p.innerHTML = "Prezime posetioca: " + this.prezime;

        p = document.querySelector(".kMuzejNaziv");
        p.innerHTML = "Naziv muzeja: " + this.muzejNaziv;

        p = document.querySelector(".nazad");
        p.className="nazadd"
        p.innerHTML = "Nazad";


    }
    crtaj3(karta){
        let p = document.querySelector("h2");
        p.innerHTML = "<i>Uspesno izmenena karta<i>";
        p = document.querySelector(".kPrezime");
        p.innerHTML = "<h3>Nova rezervacija</h3>"

        p = document.querySelector(".kMuzejNaziv");
        p.innerHTML = "Ime: " + this.ime+"</br>Prezime: " + this.prezime + "</br>Muzej: "+this.muzejNaziv;

        p = document.querySelector(".nazad");
        p.className="nazadd"
        p.innerHTML = "Nazad";


    }
}