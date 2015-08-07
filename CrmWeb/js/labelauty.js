(function ($) {
    $.fn.labelauty = function (tag, tag2) {
        
        //判断是否选中
        rdochecked(tag);

        //单选or多选
        if (tag2 == "rdo") {
            //单选
            $(".rdobox").click(function () {
                $(this).prev().prop("checked", "checked");
                rdochecked(tag);
            });
        } else {
            //多选
            $(".chkbox").click(function () {
                //
                if ($(this).prev().prop("checked") == true) {
                    $(this).prev().removeAttr("checked");
                }
                else {
                    $(this).prev().prop("checked", "checked");
                }
                rdochecked(tag);
            });
        }




        $(".HealthGuominWu").click(function () {
            // $("input[name='HealthGuomin']").removeAttr("checked");
            $("input[name='HealthGuomin']").removeAttr("checked");
            rdochecked(tag);

        });
        $(".HealthGuomin").click(function () {

            $(".HealthGuominWu").removeAttr("checked");
            rdochecked(tag);
          

        });

       


        $(".HealthJiazuDadyWu").click(function () {
            // $("input[name='HealthGuomin']").removeAttr("checked");
            $("input[name='HealthJiazuDady']").removeAttr("checked");
            rdochecked(tag);

        });
        $(".HealthJiazuDady").click(function () {

            $(".HealthJiazuDadyWu").removeAttr("checked");
            rdochecked(tag);
        });



        $(".HealthJibingWu").click(function () {
            // $("input[name='HealthGuomin']").removeAttr("checked");
            $("input[name='HealthJibing']").removeAttr("checked");
            rdochecked(tag);

        });
        $(".HealthJibing").mouseup(function () {
           // alert($(this).find("span[class=radiobox-content]").text());
            $(".HealthJibingWu").removeAttr("checked");
            
           // alert($(this).prev().prop('tagName'));
           // alert($(this).prev().prop("checked"));
            if ($(this).prev().prop("checked") == false)
               {
            $("#JibingAddForm").show();
            $("#JiwangshiName").val($(this).find("span[class=radiobox-content]").text());
            $("#JiwangshiJibingClass").val($(this).find("span[class=radiobox-content]").text());
            
           }
            rdochecked(tag);
        });




        $(".HealthJiazuMamaWu").click(function () {
            $("input[name='HealthJiazuMama']").removeAttr("checked");
            rdochecked(tag);

        });
        $(".HealthJiazuMama").click(function () {

            $(".HealthJiazuMamaWu").removeAttr("checked");
            rdochecked(tag);


        });

        $(".HealthJiazuXiongdiWu").click(function () {
            $("input[name='HealthJiazuXiongdi']").removeAttr("checked");
            rdochecked(tag);

        });
        $(".HealthJiazuXiongdi").click(function () {

            $(".HealthJiazuXiongdiWu").removeAttr("checked");
            rdochecked(tag);


        });

        $(".HealthJiazuZinvWu").click(function () {
            $("input[name='HealthJiazuZinv']").removeAttr("checked");
            rdochecked(tag);

        });
        $(".HealthJiazuZinv").click(function () {

            $(".HealthJiazuZinvWu").removeAttr("checked");
            rdochecked(tag);


        });



        $(".HealthBaolouWu").click(function () {
            
            $("input[name='HealthBaolou']").removeAttr("checked");
            rdochecked(tag);

        });
        $(".HealthBaolou").click(function () {

            $(".HealthBaolouWu").removeAttr("checked");
            rdochecked(tag);


        });

        $(".HealthCanjiWu").click(function () {

            $("input[name='HealthCanji']").removeAttr("checked");
            rdochecked(tag);

        });
        $(".HealthCanji").click(function () {

            $(".HealthCanjiWu").removeAttr("checked");
            rdochecked(tag);


        });







        //判断是否选中
        function rdochecked(tag) {
            $('.' + tag).each(function (i) {
                var rdobox = $('.' + tag).eq(i).next();
                if ($('.' + tag).eq(i).prop("checked") == false) {
                    rdobox.removeClass("checked");
                    rdobox.addClass("unchecked");
                    rdobox.find(".check-image").css("background", "url(/images/input-unchecked.png)");
                }
                else {
                    rdobox.removeClass("unchecked");
                    rdobox.addClass("checked");
                    rdobox.find(".check-image").css("background", "url(/images/input-checked.png)");
                }
            });
        }

       



    }




}(jQuery));