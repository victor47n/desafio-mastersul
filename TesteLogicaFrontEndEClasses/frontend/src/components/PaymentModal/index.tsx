import Modal from 'react-modal';

import styles from './styles.module.scss';

type Payment = {
    id: number;
    type: string;
    value: number;
}

type PaymentModalProps = {
    isOpen: boolean;
    onRequestClose: () => void;
    onRemovePayment: (id: number) => void;
    payment: Payment;
}

export function PaymentModal({ isOpen, onRequestClose, onRemovePayment, payment }: PaymentModalProps) {
    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onRequestClose}
            overlayClassName="react-modal-overlay"
            className="react-modal-content"
        >
            <button
                type="button"
                onClick={onRequestClose}
                className="react-modal-close"
            >
                <img src="/close.svg" alt="Fechar modal" />
            </button>

            <div className={styles.container}>
                <h2>Cadastrar transação</h2>

                <input
                    placeholder="Tipo"
                    value={payment.type}
                    readOnly
                />

                <input
                    placeholder="Valor"
                    value={new Intl.NumberFormat('pt-BR', {
                        style: 'currency',
                        currency: 'BRL'
                    }).format(payment.value)}
                    readOnly
                />

                <button onClick={() => onRemovePayment(payment.id)}
                >
                    Remover
                </button>
            </div>
        </Modal>
    );
}