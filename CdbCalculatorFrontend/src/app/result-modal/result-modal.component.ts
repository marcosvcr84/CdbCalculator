import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

export interface CdbResult {
  GrossValue: number;
  NetValue: number;
}

@Component({
  selector: 'app-result-modal',
  templateUrl: './result-modal.component.html',
  styleUrls: ['./result-modal.component.scss']
})
export class ResultModalComponent {
  constructor(public dialogRef: MatDialogRef<ResultModalComponent>, @Inject(MAT_DIALOG_DATA) public data: CdbResult) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
