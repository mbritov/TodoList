import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../services/tasks.service';

@Component({
  selector: 'app-modal',
  templateUrl: './update-task.component.html',
})

export class UpdateTaskComponent implements OnInit {
  _baseUrl = '';
  currentTask = null

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.getTask(this.route.snapshot.paramMap.get('id'));
  }

  getTask(id): void {
    this.taskService.get(id)
      .subscribe(
        data => {
          this.currentTask = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  public saveTask() {
    this.taskService.update(this.currentTask)
      .subscribe(result => {
        this.router.navigate(['task-list']);
      },
      error => console.error(error));
  }
}
