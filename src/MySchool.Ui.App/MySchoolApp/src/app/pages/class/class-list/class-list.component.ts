import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Class } from '../shared/class.model';
import { ClassService } from '../shared/class.service';

@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.css'],
})
export class ClassListComponent implements OnInit {
  schoolClasses: Class[] = [];

  constructor(
    private classService: ClassService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadClasses();
  }

  loadClasses() {
    const urlSnapShot = this.route.snapshot.url[0].path;
    if (urlSnapShot != null) {
      let schoolId = Guid.parse(urlSnapShot);
      this.classService.getAllBySchoolId(schoolId).subscribe(
        (classes) => (this.schoolClasses = classes),
        (error) => alert('Erro ao carregar a lista')
      );
    }
  }

  actionsForEditClass(id: Guid): void {
    debugger;
    const urlSnapShot = this.route.snapshot.url[0].path;
    this.router
    .navigateByUrl('turmas', { skipLocationChange: true })
    .then(() => this.router.navigate(['turmas','edit' , `${urlSnapShot}`, `${id}`]));
  }

  actionsForNewClass(): void {
    const urlSnapShot = this.route.snapshot.url[0].path;
    this.router.navigate(['turmas/new', urlSnapShot]);
  }

  actionsForReturnToSchools(){
    this.router.navigate(['']);
  }

  deleteClass(schoolClass: any) {
    const mustDelete = confirm('Deseja realmente excluir este item?');

    if (mustDelete) {
      this.classService.delete(schoolClass.id).subscribe(
        () =>
          (this.schoolClasses = this.schoolClasses.filter(
            (element) => element != schoolClass
          )),
        () => alert('Erro ao tentar excluir!')
      );
    }
  }
}
