var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component, Input } from '@angular/core';
import { DataService } from '../data.service';
let PhoneDetailComponent = class PhoneDetailComponent {
    constructor(route, dataService, location) {
        this.route = route;
        this.dataService = dataService;
        this.location = location;
    }
    ngOnInit() {
        this.getPhone();
    }
    getPhone() {
        const id = +this.route.snapshot.paramMap.get('id');
        this.dataService.getPhone(id)
            .subscribe((data) => this.phone = data);
    }
};
__decorate([
    Input()
], PhoneDetailComponent.prototype, "phone", void 0);
PhoneDetailComponent = __decorate([
    Component({
        selector: 'phone-detail',
        templateUrl: './phone-detail.component.html',
        providers: [DataService]
    })
], PhoneDetailComponent);
export { PhoneDetailComponent };
//# sourceMappingURL=phone-detail.component.js.map