import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
//import { AddTaskComponent } from './addtask.component';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public allTasks: Task[];
  public pendingTasks: Task[];
  public completedTasks: Task[];

  //constructor(public matDialog: MatDialog, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Task[]>(baseUrl + 'Todo/')
      .subscribe(result => {
        this.allTasks = result;
        this.completedTasks = result.filter(task => task.status == 0);
        this.pendingTasks = result.filter(task => task.status == 1);
      },
      error => console.error(error));
  }

  createTask(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      //const dialogConfig = new MatDialogConfig();
      //// The user can't close the dialog by clicking outside its body
      //dialogConfig.disableClose = true;
      //dialogConfig.id = "modal-component";
      //dialogConfig.height = "350px";
      //dialogConfig.width = "600px";
      //// https://material.angular.io/components/dialog/overview
      //const modalDialog = this.matDialog.open(AddTaskComponent, dialogConfig);

  }

  actionFunction() {
    alert("You have logged out.");
    this.closeModal();
  }

  closeModal() {
  //  this.dialogRef.close();
  }
}

interface Task {
  id: number;
  subject: string;
  description: string;
  status: number;
  //summary: string;
}
