import { Component, OnInit, Input } from '@angular/core';
import { Phone } from '../phone';
import { DataService } from '../data.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';


@Component({
  selector: 'phone-detail',
    templateUrl: './phone-detail.component.html',
    providers: [DataService]
})
export class PhoneDetailComponent implements OnInit {
    @Input() phone: Phone;
    constructor(
        private route: ActivatedRoute,
        private dataService: DataService,
        private location: Location
    ) { }

    ngOnInit(): void {
        this.getPhone();
    }

    getPhone(): void {
        const id = +this.route.snapshot.paramMap.get('id');
        this.dataService.getPhone(id)
            .subscribe((data: Phone) => this.phone = data);
    }

}
