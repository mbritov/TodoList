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
      this.router.navigate(['fetch-data']);
    },
    error => console.error(error));
  }
}

interface Task {
  id: number;
  subject: string;
  description: string;
  status: number;
}
