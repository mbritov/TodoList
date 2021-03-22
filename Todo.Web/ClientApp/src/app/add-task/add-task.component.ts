import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { TaskService } from '../services/tasks.service';

@Component({
  selector: 'app-modal',
  templateUrl: './add-task.component.html'
})

export class AddTaskComponent implements OnInit {
  _baseUrl = '';
  task = { subject: '', description: '' };

  constructor(
    private taskService: TaskService,
    private router: Router) { }

  ngOnInit() {}

  public saveTask() {
    this.taskService.create(this.task)
    .subscribe(result => {
      this.router.navigate(['task-list']);
    },
    error => console.error(error));
  }
}
