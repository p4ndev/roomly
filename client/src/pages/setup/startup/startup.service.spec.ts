import { of } from "rxjs";

export class MockStartupService {
    load = jasmine.createSpy('load').and.returnValue(of(null));
}