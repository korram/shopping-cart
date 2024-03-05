'use client'
import { Col, Row } from 'antd';
import Link from 'next/Link';
import { useState, useEffect } from "react";
import { listCart, updateCart, deleteAll, deleteCart } from "@/services/cart-service";
import { createOrder } from "@/services/order-service";
import { EditOutlined, EllipsisOutlined, SettingOutlined } from '@ant-design/icons';
import { Avatar, Card, Button, InputNumber } from 'antd';
import { ShoppingCartOutlined, ShoppingOutlined } from '@ant-design/icons';
import { useRouter } from 'next/navigation'
const { Meta } = Card;
function Checkout() {
    const [carts, setCarts] = useState([]);
    const [total, setTotal] = useState([]);
    const { push } = useRouter();

    const fetchData = async () => {
        const carts = await listCart();
        setCarts(carts);
        
        var sum = carts.map(t=> (t.amount * t.unitPrice)).reduce((accumulator, currentValue) => {
            return accumulator + currentValue
          },0);
          setTotal(sum)
    }
    function amountChange(cart, value) {

        setCarts((prev) => {
            const tmpCard = prev.find(t => t.id == cart.id);
            console.log(tmpCard)
            tmpCard.amount = value
            const arr = [...prev.filter(t => t.id != tmpCard.id), tmpCard];
            console.log(arr)
            return arr
        });
        cart.amount = value;
        updateCart(cart);
    }
    async function deleteItem(cart) {
        await deleteCart(cart.id);
        fetchData();
    }
    async function deleteItemAll(cart) {
        await deleteAll();
        fetchData();
    }
    async function pay(cart) {
        await createOrder();
        alert('สั่งซื้อสำเร็จแล้ว')
        push('/');
    }
    useEffect(() => {
        fetchData();
    }, []);

    return (<div style={{ padding: '20px' }}>
        <Row>
            <Col span="12"></Col>
            <Col span="6"><Button onClick={() => clickCheckout()}>ชำระเงิน</Button></Col>
            <Col span="6"><Link href="/">Back to Home</Link></Col>
        </Row>
        <Row>
            <Col span="12">Product</Col>
            <Col span="6">Amount</Col>
            <Col span="6">Total</Col>
        </Row>
        {/* {JSON.stringify(carts)} */}
        {carts?.map((cart) => {
            return (
                <Row>
                    <Col span="12">{cart.unitPrice}{cart.productCode} {cart.productName} (คงเหลือ {cart.stockAmount})</Col>
                    <Col span="6">{cart.amount}</Col>
                    <Col span="6">{(cart.amount * cart.unitPrice).toLocaleString(navigator.language, { minimumFractionDigits: 0 })}</Col>
                </Row>
            )
        })}
        <Row>
            <Col span="12"></Col>
            <Col span="6"></Col>
            <Col span="6">{(total).toLocaleString(navigator.language, { minimumFractionDigits: 0 })} <Button onClick={() => pay()}>confirm</Button></Col>
        </Row>
    </div >);
}
export default Checkout;