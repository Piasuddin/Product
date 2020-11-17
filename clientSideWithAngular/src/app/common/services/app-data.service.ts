import { Injectable, EventEmitter } from "@angular/core";
import { ResponseMessage } from '../models/response-message.model';

@Injectable()
export class AppDataService{
    responseMessageEvent: EventEmitter<ResponseMessage> = new EventEmitter<ResponseMessage>();
    sibarToggleEvent: EventEmitter<any> = new EventEmitter();
    isSidebarOpen: boolean = false;
    responseMessageData: ResponseMessage;
    setValueToResponseMessageProperty(data: ResponseMessage){
        this.responseMessageData = data;
        this.responseMessageEvent.emit(this.responseMessageData);
    }
    setValueToShowSideNav(isOpen: boolean){
        this.isSidebarOpen = this.isSidebarOpen;
        this.sibarToggleEvent.emit(this.isSidebarOpen);
    }
}