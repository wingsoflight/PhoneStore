import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Phone } from './phone';

@Injectable()
export class DataService {

    private url = "/api/phones";

    constructor(private http: HttpClient) {
    }

    getPhones() {
        return this.http.get(this.url);
    }

    getPhone(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createPhone(phone: Phone) {
        return this.http.post(this.url, phone);
    }
    updatePhone(phone: Phone) {

        return this.http.put(this.url, phone);
    }
    deletePhone(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}