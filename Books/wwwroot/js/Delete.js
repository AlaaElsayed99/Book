$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);
        const sw = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });
        sw.fire({
            title: 'Are you sure that you need to delete th book',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Books/Delete/${btn.data('id')}`,
                    method: 'Delete',
                    success: function () {
                        sw.fire(
                            'Deleted!',
                            'Book has been deleted.',
                            'success'
                        );
                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        sw.fire(
                            'Deleted!',
                            'some thing went wrong',
                            'error'
                        );
                    }
                });
                
            } 
        })
        
    });
});