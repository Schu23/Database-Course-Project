$(function(){
    // 添加一条明细
    $('#addClothes').click(function(){
        clothId = $(this).prev().prev().children("select");
        amount = $(this).prev().children("input");
        clothId.attr("disabled",true);
        amount.attr('disabled',true);
        $('#addClothes').hide();
        $('#deleteClothes').show();
        $('#inline-2').show();
    });
    $('#addClothes-2').click(function(){
        clothId = $(this).prev().prev().children("select");
        amount = $(this).prev().children("input");
        clothId.attr("disabled",true);
        amount.attr('disabled',true);
        $('#addClothes-2').hide();
        $('#deleteClothes-2').show();
        $('#inline-3').show();
    });
    $('#addClothes-3').click(function(){
        clothId = $(this).prev().prev().children("select");
        amount = $(this).prev().children("input");
        clothId.attr("disabled",true);
        amount.attr('disabled',true);
        $('#addClothes-3').hide();
        $('#deleteClothes-3').show();
        $('#inline-4').show();
    });
    $('#addClothes-4').click(function(){
        clothId = $(this).prev().prev().children("select");
        amount = $(this).prev().children("input");
        clothId.attr("disabled",true);
        amount.attr('disabled',true);
        $('#addClothes-4').hide();
        $('#deleteClothes-4').show();
        $('#inline-5').show();
    });
    $('#addClothes-5').click(function(){
        clothId = $(this).prev().prev().children("select");
        amount = $(this).prev().children("input");
        clothId.attr("disabled",true);
        amount.attr('disabled',true);
        $('#addClothes-5').hide();
        $('#deleteClothes-5').show();
    });
    // 添加一条明细
    $('#deleteClothes').click(function(){
        clothId = $(this).parent();
        clothId.remove();
        $('#deleteClothes').remove();
    });
    $('#deleteClothes-5').click(function(){
        clothId = $(this).parent();
        clothId.remove();
        $('#deleteClothes-5').remove();
    });
    $('#deleteClothes-2').click(function(){
        clothId = $(this).parent();
        clothId.remove();
        $('#deleteClothes-2').remove();
    });
    $('#deleteClothes-3').click(function(){
        clothId = $(this).parent();
        clothId.remove();
        $('#deleteClothes-3').remove();
    });
    $('#deleteClothes-4').click(function(){
        clothId = $(this).parent();
        clothId.remove();
        $('#deleteClothes-4').remove();
    });
    var line = 1;

});