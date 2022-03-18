
export class Muzej{

    constructor(id,naziv){
        this.id = id;
        this.naziv=naziv;
        this.listaMuzeja = [];
        this.kontejner = null;

    }
    Muzej(heder){
        const a=document.createElement("div");
            a.className="muzej";
            a.innerHTML=this.naziv;
            heder.appendChild(a);
    }
    
}