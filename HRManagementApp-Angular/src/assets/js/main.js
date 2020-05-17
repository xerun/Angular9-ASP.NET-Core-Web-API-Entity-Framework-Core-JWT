/*function showAlert(vicon, vtitle, vtext,redirect)
{
	if(redirect){
		Swal.fire({
		  icon: vicon,
		  title: vtitle,
		  text: vtext
		}).then(function() {
		    window.location = "employeeList";
		});
	}
	else
	{
		Swal.fire({
		  icon: vicon,
		  title: vtitle,
		  text: vtext
		})
	}
}

function confirmDelete(vicon, vtitle, vtext, url)
{
	Swal.fire({
		  title: vtitle,
		  text: vtext,
		  icon: vicon,
		  showCancelButton: true,
		  confirmButtonColor: '#3085d6',
		  cancelButtonColor: '#d33',
		  confirmButtonText: 'Yes, delete it!'
		}).then((result) => {
		  if (result.value) {
			  fetch(url)
		      .then(function(response) {
		    	  if(response.ok){
		    		  Swal.fire(
		    		      'Deleted!',
		    		      'The record has been deleted.',
		    		      'success'
			    	  ).then(function() {
			    		    window.location = "employeeList";
			    	  });
		    	  }
		      })
		  }
	})
}*/
(function ($) {
    "use strict";

    $('.datepicker').daterangepicker({
    	singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        locale: {
          format: 'YYYY-MM-DD'
        }
      });
    var extensions = {
        "sFilterInput": "form-control",
        "sLengthSelect": "form-control"
    }
    // Used when bJQueryUI is false
    //$.extend($.fn.dataTableExt.oStdClasses, extensions);
    // Used when bJQueryUI is true
    //$.extend($.fn.dataTableExt.oJUIClasses, extensions);
    //$('.dataTable').DataTable();
    /*==================================================================
    [ Focus input ]*/
    $('.input100').each(function(){
        $(this).on('blur', function(){
            if($(this).val().trim() != "") {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        })    
    })
    /*$('#phone').mask('000.000.0000');
    $('#salary').mask("#0", {reverse: true});
    $('#comm').mask('A.00', {'translation': {
        A: {pattern: /[0-1]/}
      }
    });*/
    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit',function(){
        var check = true;

        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false){
                showValidate(input[i]);
                check=false;
            }
        }

        return check;
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }   
    
    
    /*==================================================================
    [ Show pass ]*/
    var showPass = 0;
    $('.btn-show-pass').on('click', function(){
        if(showPass == 0) {
            $(this).next('input').attr('type','text');
            $(this).find('i').removeClass('zmdi-eye');
            $(this).find('i').addClass('zmdi-eye-off');
            showPass = 1;
        }
        else {
            $(this).next('input').attr('type','password');
            $(this).find('i').addClass('zmdi-eye');
            $(this).find('i').removeClass('zmdi-eye-off');
            showPass = 0;
        }
        
    });


})(jQuery);