import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Class } from '../shared/class.model';
import { ClassService } from '../shared/class.service';
import toastr from 'toastr';
import { switchMap } from 'rxjs/operators';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-class-form',
  templateUrl: './class-form.component.html',
  styleUrls: ['./class-form.component.css'],
})
export class ClassFormComponent implements OnInit {
  currentAction: string = '';
  classForm: FormGroup;
  pageTitle: string = '';
  serverErrorMessages: string[];
  submittingForm = false;
  schoolClass: Class = new Class();

  constructor(
    private classService: ClassService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    this.setCurrentAction();
    this.loadClass();
    this.buildClassForm();
  }

  ngAfterContentChecked() {
    this.setPageTitle();
  }

  submitForm() {
    debugger;
    if (this.currentAction == 'new') {
      this.createClass();
    } else {
      this.updateClass();
    }
  }

  //PRIVATE METHODS
  private setCurrentAction() {
    const urlSnapShot = this.route.snapshot.url[0].path;
    if (urlSnapShot == 'new') {
      this.currentAction = 'new';
    } else {
      this.currentAction = 'edit';
    }
  }

  private buildClassForm() {
    this.classForm = this.formBuilder.group({
      id: [null],
      name: [null, [Validators.required, Validators.minLength(3)]],
      shift: [null, [Validators.required, Validators.minLength(3)]],
      degree: [null, [Validators.required, Validators.minLength(3)]],
    });
  }

  private loadClass() {
    debugger;
    if (this.currentAction == 'edit') {
      this.route.paramMap
        .pipe(
          switchMap((params) =>
            this.classService.getById(Guid.parse(params.get('class')))
          )
        )
        .subscribe(
          (schoolClass) => {
            this.schoolClass = schoolClass;
            this.classForm?.patchValue(schoolClass); // preenchendo o Formulario com o obj Class obtido atraves do medoto GetById
          },
          (error) =>
            alert('Ocorreu um erro no servidor, tente novamente mais tarde.')
        );
    }
  }

  private setPageTitle() {
    if (this.currentAction == 'new') {
      this.pageTitle = 'Cadastro de Nova Turma';
    } else {
      const className = this.schoolClass.name || '';
      this.pageTitle = 'Editando a Turma: ' + className;
    }
  }

  private createClass() {
    const urlSnapShot = this.route.snapshot.url[1].path;
    debugger;
    if (urlSnapShot != null) {
      const schoolIdLocal = urlSnapShot;
      let schoolClass: Class = Object.assign(
        new Class(),
        this.classForm?.value
      );
      schoolClass.schoolId = schoolIdLocal;
      schoolClass.notifications = null;
      schoolClass.invalid = null;
      schoolClass.valid = null;

      this.classService.create(schoolClass).subscribe(
        (schoolClass) => this.actionsForSuccess(schoolClass),
        (error) => this.actionsForError(error)
      );
    }
  }

  private updateClass() {
    const schoolClass: Class = Object.assign(
      new Class(),
      this.classForm?.value
    );

    this.classService.update(schoolClass).subscribe(
      (schoolClass) => toastr.success('Processamento realizado com sucesso.'),
      (error) => this.actionsForError(error)
    );
  }

  private actionsForSuccess(schoolClass: Class): void {
    debugger;
    toastr.success('Processamento realizado com sucesso.');

    this.router
    .navigateByUrl('turmas', { skipLocationChange: true })
    .then(() => this.router.navigate(['turmas','edit' , `${schoolClass.schoolId}`, `${schoolClass.id}`]));
  }

  actionsForReturnAddClass(){
    debugger;
    let urlSnapShot = ""
    if (this.currentAction == 'new') {
      urlSnapShot = this.route.snapshot.url[1].path;
    }else{
      urlSnapShot = this.route.snapshot.url[1].path;
    }
    
    this.router.navigateByUrl('turmas', { skipLocationChange: true })
    .then(() => this.router.navigate(['turmas', `${urlSnapShot}`]));
  }

  private actionsForError(error: any) {
    debugger;
    toastr.error('Erro ao processar dados.');

    this.submittingForm = false;

    if (error.status === 422) {
      this.serverErrorMessages = JSON.parse(error._body).erros;
    } else {
      this.serverErrorMessages = [
        'Houve uma falha de comunicação com o servidor.',
      ];
    }
  }
}
