"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//@Injectable({
//  providedIn: 'root'
//})
var TaskService = /** @class */ (function () {
    function TaskService(http) {
        this.http = http;
        this._baseUrl = '';
        //this._baseUrl = baseUrl;
    }
    TaskService.prototype.getAll = function () {
        return this.http.get(this._baseUrl + 'Todo/');
    };
    TaskService.prototype.get = function (id) {
        return this.http.get(this._baseUrl + "/" + id);
    };
    TaskService.prototype.create = function (data) {
        return this.http.put(this._baseUrl, data);
    };
    TaskService.prototype.update = function (id, data) {
        return this.http.put(this._baseUrl + "/" + id, data);
    };
    return TaskService;
}());
exports.TaskService = TaskService;
//# sourceMappingURL=tasks.service.js.map