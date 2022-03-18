export class Predmeti{

    constructor(naziv,tip,godina,tvorac,era,){
        this.naziv = naziv;
        this.tip = tip;
        this.godina = godina;
        this.tvorac = tvorac;
        this.era=era;
    }

    
    crtaj(host){
        

        var tr = document.createElement("tr");
        host.appendChild(tr);

        var n = document.createElement("td");
        n.innerHTML = this.naziv;
        n.className="ime";
        tr.appendChild(n);

        var td = document.createElement("td");
        td.innerHTML = this.tip;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = this.tvorac;
        tr.appendChild(td);

    }
}