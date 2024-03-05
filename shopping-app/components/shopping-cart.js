'use client'
import { Col, Row } from 'antd';
import Link from 'next/Link';
import { useState, useEffect } from "react";
import { listCart, updateCart, deleteAll, deleteCart } from "@/services/cart-service";
import { EditOutlined, EllipsisOutlined, SettingOutlined } from '@ant-design/icons';
import { Avatar, Card, Button, InputNumber } from 'antd';
import { ShoppingCartOutlined, ShoppingOutlined } from '@ant-design/icons';
const { Meta } = Card;
function ShoppingCart() {
    const [carts, setCarts] = useState([]);

    const fetchData = async () => {
        const carts = await listCart();
        setCarts(carts);
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
    async function clickCheckout(cart) {
        
    }
    useEffect(() => {
        fetchData();
    }, []);

    return (<div style={{ padding: '20px' }}>
        {/* {JSON.stringify(carts)} */}
        <Row>
            <Col span="18"></Col>
            <Col span="3"><Link href="/checkout">ชำระเงิน</Link></Col>
            <Col span="3"><Link href="/">Back to Home</Link></Col>
        </Row>
        <Row>
            <Col span="6">Product</Col>
            <Col span="6">Amount</Col>
            <Col span="6">Total</Col>
            <Col span="6"><Button onClick={() => deleteItemAll()}>Delete All</Button></Col>
        </Row>
        {/* {JSON.stringify(carts)} */}
        {carts?.map((cart) => {
            return (
                <Row>
                    <Col span="6">{cart.productCode} {cart.productName} (คงเหลือ {cart.stockAmount})</Col>
                    <Col span="6"><InputNumber key={cart.productId} min={1} max={cart.stockAmount} defaultValue={cart.amount} onChange={(value) => amountChange(cart, value)}></InputNumber></Col>
                    <Col span="6">{(cart.amount * cart.unitPrice).toLocaleString(navigator.language, { minimumFractionDigits: 0 })}</Col>
                    <Col span="6"><Button onClick={() => deleteItem(cart)}>Delete</Button></Col>
                </Row>
            )
        })}
    </div >);
}
export default ShoppingCart;