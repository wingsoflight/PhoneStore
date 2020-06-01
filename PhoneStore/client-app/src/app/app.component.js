var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Phone } from './phone';
let AppComponent = class AppComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.phone = new Phone(); // изменяемый товар
        this.tableMode = true; // табличный режим
    }
    ngOnInit() {
        this.loadPhones(); // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadPhones() {
        this.dataService.getPhones()
            .subscribe((data) => this.phones = data);
    }
    // сохранение данных
    save() {
        if (this.phone.id == null) {
            this.dataService.createPhone(this.phone)
                .subscribe((data) => this.phones.push(data));
        }
        else {
            this.dataService.updatePhone(this.phone)
                .subscribe(data => this.loadPhones());
        }
        this.cancel();
    }
    editPhone(p) {
        this.phone = p;
    }
    cancel() {
        this.phone = new Phone();
        this.tableMode = true;
    }
    delete(p) {
        this.dataService.deletePhone(p.id)
            .subscribe(data => this.loadPhones());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
    selectPhone(p) {
        this.phone = p;
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './app.component.html',
        providers: [DataService]
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map