import { Component, Inject } from '@angular/core';
import { TaskService } from '../services/tasks.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})

export class FetchDataComponent {
  public pendingTasks: Task[];
  public completedTasks: Task[];

  constructor(private taskService: TaskService) {
    this.taskService.getAll().subscribe(result => {
        this.completedTasks = result.filter(task => task.status == 1);
        this.pendingTasks = result.filter(task => task.status == 0);
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
