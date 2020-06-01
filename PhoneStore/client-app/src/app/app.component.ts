import { Component, OnInit, NgModule } from '@angular/core';
import { DataService } from './data.service';
import { Phone } from './phone';


@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})

export class AppComponent implements OnInit {

    phone: Phone = new Phone();   // изменяемый товар
    phones: Phone[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadPhones();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadPhones() {
        this.dataService.getPhones()
            .subscribe((data: Phone[]) => this.phones = data);
    }
    // сохранение данных
    save() {
        if (this.phone.id == null) {
            this.dataService.createPhone(this.phone)
                .subscribe((data: Phone) => this.phones.push(data));
        } else {
            this.dataService.updatePhone(this.phone)
                .subscribe(data => this.loadPhones());
        }
        this.cancel();
    }
    editPhone(p: Phone) {
        this.phone = p;
    }
    cancel() {
        this.phone = new Phone();
        this.tableMode = true;
    }
    delete(p: Phone) {
        this.dataService.deletePhone(p.id)
            .subscribe(data => this.loadPhones());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
    selectPhone(p: Phone): void{
        this.phone = p;
    }
}