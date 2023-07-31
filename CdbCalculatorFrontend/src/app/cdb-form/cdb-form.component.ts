import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResultModalComponent } from '../result-modal/result-modal.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-cdb-form',
  templateUrl: './cdb-form.component.html',
  styleUrls: ['./cdb-form.component.scss']
})
export class CdbFormComponent {
    initialValue: number = 0;
    months: number = 0;
    grossValue: number = 0;
    netValue: number = 0;

    constructor(private http: HttpClient, private dialog: MatDialog) { }

    calculate() {
      this.http.post<CdbResult>('http://localhost:44382/api/CdbCalculator/Calculate', {
          initialValue: this.initialValue,
          months: this.months
      }).subscribe(result => {
          this.grossValue = result.GrossValue;
          this.netValue = result.NetValue;
          this.dialog.open(ResultModalComponent, { data: result });
      });
  }
}

interface CdbResult {
    GrossValue: number;
    NetValue: number;
}
