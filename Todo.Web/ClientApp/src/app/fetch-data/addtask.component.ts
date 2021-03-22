import { Component, OnInit } from '@angular/core';

//import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-modal',
  templateUrl: './addtask.component.html',
  //styleUrls: ['./modal.component.css']
})

export class AddTaskComponent implements OnInit {

  //constructor(public dialogRef: MatDialogRef<AddTaskComponent>) { }
  constructor() { }

  ngOnInit() {

//    var newTask = { subject: "1", description: "desc2", status: 0 };
//    http.put<Task[]>(baseUrl + 'Todo/', newTask)
//      .subscribe(result => {
////      this.pendingTasks = result.filter(task => task.status == 1);
//      },
//      error => console.error(error));
  }

  // When the user clicks the action button a.k.a. the logout button in the\
  // modal, show an alert and followed by the closing of the modal
  actionFunction() {
    alert("You have logged out.");
    this.closeModal();
  }

  // If the user clicks the cancel button a.k.a. the go back button, then\
  // just close the modal
  closeModal() {
    //this.dialogRef.close();
  }
}
