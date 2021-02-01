import { Component, Injector, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { BaseResourceFormComponent } from 'src/app/shared/components/base-resource-form/base-resource-form.component';
import { School } from '../shared/school.model';
import { SchoolService } from '../shared/school.service';


@Component({
  selector: 'app-school-form',
  templateUrl: './school-form.component.html',
  styleUrls: ['./school-form.component.css'],
})
export class SchoolFormComponent extends BaseResourceFormComponent<School> {
  constructor(
    protected schoolService: SchoolService,
    protected injector: Injector
  ) {
    super(injector, new School(), schoolService, School.fromJson);
  }

  imaskConfigZipCode = {
    mask: /^[1-9]\d{0,7}$/,
  };

  imaskConfigCnpj = {
    mask: /^[0-9]\d{0,13}$/,
  };

  imaskConfigNumber = {
    mask: /^[0-9]\d{0,10}$/,
  };

  protected buildResourceForm() {
    this.resourceForm = this.formBuilder.group({
      id: [null],
      name: [null, [Validators.required, Validators.minLength(3)]],
      cnpj: [null, [Validators.required, Validators.minLength(3)]],
      street: [null, [Validators.required, Validators.minLength(3)]],
      number: [null, [Validators.required, Validators.minLength(1)]],
      neighborhood: [null, [Validators.required, Validators.minLength(3)]],
      city: [null, [Validators.required, Validators.minLength(3)]],
      state: [null, [Validators.required, Validators.minLength(3)]],
      country: [null, [Validators.required, Validators.minLength(3)]],
      zipCode: [null]
    });
  }

  protected creationPageTitle(): string {
    return 'Cadastro de Nova Escola';
  }

  protected editionPageTitle(): string {
    const escolaName = this.resource.name || '';
    return 'Editando Escola: ' + escolaName;
  }
}
