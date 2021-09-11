//validate form login
$(function () {
	$("form[name='loginForm']").validate({
		rules: {
			Email: {
				required: true,
				email: true,
			},
			Password: {
				required: true,
				minlength: 8,
			}
		},
		messages: {
			Email: {
				required: 'Bạn không thể để trống dữ liệu này',
				email: 'Email không hợp lệ',
			},
			Password: {
				required: 'Bạn không thể để trống dữ liệu này',
				minlength: 'Mật khẩu ít nhất 8 ký tự',
			}
		}
	});
});


//validate order form
$(function () {
	$("form[name='orderForm']").validate({
		rules: {
			ReceiveName: {
				required: true	
			},
			Phone: {
				required: true,
				phoneVN:true
				
			},
			Address: {
				required: true
			},
			Province: {
				required: true
			},
			District: {
				required: true
			},
			Homlet: {
				required: true
			}
		},
		messages: {
			ReceiveName: {
				required: 'Bạn không thể để trống dữ liệu này'
			},
			Phone: {
				required: 'Bạn không thể để trống dữ liệu này',
				phoneVN: 'Số điện thoại chưa đúng đinh dạng',
			},
			Address: {
				required: 'Bạn không thể để trống dữ liệu này'
			},
			Province: {
				required: 'Bạn không thể để trống dữ liệu này'
			},
			District: {
				required: 'Bạn không thể để trống dữ liệu này'
			},
			Homlet: {
				required: 'Bạn không thể để trống dữ liệu này'
			}
		}
	});
});

//validate phone /^(\+?1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/

jQuery.validator.addMethod("phoneVN", function (phone_number, element) {
	phone_number = phone_number.replace(/\s+/g, "");
	return this.optional(element) || phone_number.length > 9 &&
		phone_number.match(/([0-9]{10})|(\([0-9]{3}\)\s+[0-9]{3}\-[0-9]{4})/);
}, "");


var gender = $('.breakcumA').text();
var category = $('.breakcumB').text();
var minPri = Number($('#minamount').val().slice(0, $('#minamount').val().length - 1));
var maxPri = Number($('#maxamount').val().slice(0, $('#maxamount').val().length - 1));
var productColor = "";
var size = 0;
// choose color
var colorArr = ["#label_color_while", "#label_color_yellow", "#label_color_red", "#label_color_black", "#label_color_blue", "#label_color_green"];
for (var i = 0; i < colorArr.length; i++) {
	$(colorArr[i]).click(function () {
		var color = $(this).children().val();
		productColor = color;
		sort(gender, category, minPri, maxPri, productColor, size);
	});
}

//choose price
$('.ui-slider-handle').mouseup(function () {
	var a = $('#minamount').val();
	var b = $('#maxamount').val();
	minPri = Number(a.slice(0, a.length - 1));
	maxPri = Number(b.slice(0, b.length - 1));
	sort(gender, category, minPri, maxPri, productColor, size);
});

// choose size
var sizeArr = ["#lbl_size_35", "#lbl_size_36", "#lbl_size_37", "#lbl_size_38", "#lbl_size_39", "#lbl_size_40",
	"#lbl_size_41", "#lbl_size_42", "#lbl_size_43", "#lbl_size_44", "#lbl_size_45",];
for (var i = 0; i < sizeArr.length; i++) {
	$(sizeArr[i]).click(function () {
		var s = Number((this).text);
		size = s;
		sort(gender, category, minPri, maxPri, productColor, size);
	});
}
//sắp xếp
function sort(gen, cate, minPri, maxPri, productCo, si) {
	var domain = 'https://' + window.location.host;
	
	$.ajax({
		url: domain +'/Product/Sort',
		charset: "UTF-8",
		contentType: "text/html; charset=UTF-8",
		type: 'GET',
		dataType: 'json',
		data: {
			gender: gen,
			category: cate,
			minPrice: minPri,
			maxPrice: maxPri,
			color: productCo,
			size: si
		},
		success: function (data) {
			$('.product_container').remove();
			$('.product_quanity').text(data.length);
			for (var i = 0; i < data.length; i++){
				console.log(data.length);
				console.log(data[i]);
				var a = "<div class='col-lg-4 col-md-6 col-sm-6 product_container'>" +
					"<div class='product__item'>" +
					"<div class='product__item__pic set-bg' data-setbg='" + data[i].mainImg + "'>" +
					"<ul class='product__item__pic__hover'>" +
					"<li><a href='wish-list.html'><i class='fa fa-heart'></i></a></li>" +
					"<li><a class='product_detail' href='" + domain + "/Product/ProductDetail/" + data[i].productId + "'><i class='fa fa-retweet'></i></a></li>" +
					"<li><a class='add_cart' onclick='addToCart(" + data[i].productId + ")'><i class='fa fa-shopping-cart'></i></a></li>" +
					"</ul>" +
					"</div>" +
					"<div class='product__item__text'>" +
					"<h6><a class='product_detail' asp-controller='Product' asp-action='ProductDetail' asp-route-id='" + data[i].productId + "'>" + data[i].productName + "</a></h6>" +
					"<h5>" + data[i].price + "đ</h5>" +
					"</div>" +
					"</div>" +
					"</div>";

				$('.product .list_product').append(a);
				$('.set-bg').each(function () {
					var bg = $(this).data('setbg');
					$(this).css('background-image', 'url(' + bg + ')');
				});
				
				$('a').hover(function () {
					$(this).css('cursor', 'pointer');
				});
			}
		}
	});
}

// add to cart
var quantity = 1;
function addToCart(productID) {
	var domain = 'https://' + window.location.host;
	var userLogin = $('#account-link').val();
	quantity = quantity + 1;
	if (userLogin != null) {
		$.ajax({
			url: domain+'/Cart/AddToCart',

			type: 'POST',
			data: {
				ProductId: productID,
				quanlity: 1
			},
			success: function (data) {

				$.notify("Đã thêm vào giỏ hàng", "success");
				$('.notifyjs-corner').css('top', '50%');
				$('.notifyjs-corner').css('right', '40%');
			}
		});

	}
}

//Xóa cart item ra khỏi cart
function deleteCartItem(itemID, btn) {
	$.ajax({
		url: 'Cart/deleteCartItem',
		type: 'DELETE',
		data: {
			cartItemID: itemID
		},
		success: function (data) {
			var row = btn.parentNode.parentNode;
			row.parentNode.removeChild(row);
			updateTotalPrice();
		}
	});
}

// cập nhật giá

function updateTotalPrice() {
	var priceInItem = $('.shoping__cart__total').text();
	console.log(priceInItem);
	var a = priceInItem.split("đ");

	var total = 0;
	for (var i = 0; i < a.length; i++) {
		var item = Number(a[i].slice(0, a[i] - 1));
		total += item;
		console.log(item);
	}
	console.log(total);
	$('.shoping__checkout ul li span').text(total + "đ");

}
//check out successful




