import { HttpErrorResponse, HttpEvent, HttpInterceptorFn } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';

export const errorhandlingInterceptor: HttpInterceptorFn = (req, next): Observable<HttpEvent<unknown>> => {
  const toastr = inject(ToastrService);
  const router = inject(Router);

  const clone = req.clone({
    setHeaders: {
      Authorization: 'Bearer [the token]',
    },
  });

  return next(clone).pipe(
    catchError((_error: HttpErrorResponse) => {
      if (_error) {
        switch (_error.status) {
          case 400:
            if (_error.error.errors) {
              const errors = [];
              for (const key in _error.error.errors) {
                if (_error.error.errors[key]) {
                  errors.push(_error.error.errors[key]);
                }
              }
              toastr.error(errors.flat().join('\n'), _error.status.toString());
            } else {
              toastr.error(_error.error, _error.status.toString());
            }
            break;
          case 401:
            toastr.error("Unauthorized", _error.status.toString());
            break;
          case 404:
            router.navigateByUrl('not-found');
            break;
          case 500:
            const navExtras: NavigationExtras = { state: { error: _error.error } };
            router.navigateByUrl('server-error', navExtras);
            break;
          default:
            toastr.error('Something unexpected went wrong.');
            console.error(_error);
            break;
        }
      }
      return throwError(() => _error);
    })
  );
};
