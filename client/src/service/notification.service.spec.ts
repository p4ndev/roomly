export class MockNotificationService {
    notify = jasmine.createSpy('notify');
    close = jasmine.createSpy('close');
}